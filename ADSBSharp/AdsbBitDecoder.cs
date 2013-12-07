using System;
using System.Collections.Generic;
using System.Linq;

namespace ADSBSharp
{
    public delegate void FrameReceivedDelegate(byte [] frame, int actualLength);

    public class AdsbBitDecoder
    {
        public event FrameReceivedDelegate FrameReceived;

        private const int LongFrameLengthBits = 112;
        private const int ShortFrameLengthBits = 56;
        private const int PreambleLengthBits = 16;
        private const int DefaultConfidence = 4;
        private const uint Polynomial = 0xfffa0480;
        private const int OneSecond = 2000000;
        private const float CorrectionFactor = 20.0f;

        private static readonly byte[] _preamble = { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 };

        private Dictionary<uint, ulong> _icaos = new Dictionary<uint, ulong>();
        private Dictionary<uint, int> _candidateICAOs = new Dictionary<uint, int>();
        private readonly byte[] _frame = new byte[LongFrameLengthBits / 8];
        private readonly int[] _candidate = new int[PreambleLengthBits + LongFrameLengthBits * 2];
        private int _candidateHead;
        private int _confidenceLevel = DefaultConfidence;
        private bool _reset;
        private int _timeout = 120;
        private ulong _ticks;

        public int ConfidenceLevel
        {
            get { return _confidenceLevel; }
            set { _confidenceLevel = value; }
        }

        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        public int TrustedCount
        {
            get { return _icaos.Count; }
        }

        public bool IsPreambleValid()
        {
            var lastOne = 0;
            var lastZero = 0;
            var queuePtr = _candidateHead;

            for (var i = 0 ; i < _preamble.Length ; i++)
            {
                var mag = _candidate[queuePtr];
                queuePtr = (queuePtr + 1) % _candidate.Length;

                if (_preamble[i] == 1)
                {
                    if (mag > lastZero)
                    {
                        lastOne = mag;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (mag < lastOne)
                    {
                        lastZero = mag;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void ReadData()
        {
            var queuePtr = (_candidateHead + PreambleLengthBits) % _candidate.Length;

            Array.Clear(_frame, 0, _frame.Length);
            var frameBitLength = 0;
            var lastMag = 0f;
            var lastAvg = 0f;

            for (var i = 0; i < LongFrameLengthBits * 2; i++)
            {
                var mag = (float) _candidate[queuePtr];
                queuePtr = (queuePtr + 1) % _candidate.Length;

                if (i % 2 != 0)
                {
                    //if (i == frameBitLength * 2 - 1 && _frame[0] == 0x5d && _frame[1] == 0x3c && _frame[2] == 0x4d && _frame[3] == 0xd2)
                    //{
                    //    Console.WriteLine("Ba333");
                    //}

                    var avg = (mag + lastMag) * 0.5f;
                    if (lastAvg > 0f)
                    {
                        var correction = -CorrectionFactor * (avg - lastAvg) / avg;
                        if (correction > 0)
                        {
                            mag += correction;
                            avg = (mag + lastMag) * 0.5f;
                        }
                    }
                    lastAvg = avg;

                    var bit = lastMag > mag ? 1 : 0;
                    
                    var frameBitPosition = i / 2;

                    if (bit == 1)
                    {
                        var index = frameBitPosition / 8;
                        var shift = 7 - (frameBitPosition % 8);
                        _frame[index] += (byte) (1 << shift);
                    }

                    if (frameBitPosition == 7)
                    {
                        if (_frame[0] == 0)
                        {
                            return;
                        }
                        var df = (_frame[0] >> 3) & 0x1f;
                        frameBitLength = df >= 16 ? LongFrameLengthBits : ShortFrameLengthBits;
                    }

                    if (frameBitLength > 0 && frameBitPosition == frameBitLength - 1)
                    {
                        var length = frameBitLength / 8;
                        if (_frame[length - 1] == 0 && _frame[length - 2] == 0 && _frame[length - 3] == 0)
                        {
                            return;
                        }
                        var icao = GetICAOAddress(_frame);
                        var df = (_frame[0] >> 3) & 0x1f;
                        if (df == 17 || df == 18)
                        {
                            if (GetLongFrameParity(_frame) != 0)
                            {
                                UpdateConfidenceList(icao);
                                return;
                            }
                        }
                        else if (df == 11)
                        {
                            if (GetShortFrameParity(_frame) != 0)
                            {
                                UpdateConfidenceList(icao);
                                return;
                            }
                        }
                        else if (!_icaos.ContainsKey(icao))
                        {
                            if (!UpdateConfidenceList(icao))
                            {
                                return;
                            }
                        }
                        _icaos[icao] = _ticks;
                        _candidateICAOs.Remove(icao);
                        if (FrameReceived != null)
                        {
                            FrameReceived(_frame, frameBitLength / 8);
                        }
                        return;
                    }
                }

                lastMag = mag;
            }
        }

        private bool UpdateConfidenceList(uint icao)
        {
            var rank = _candidateICAOs.ContainsKey(icao) ? _candidateICAOs[icao] : 0;
            rank++;
            _candidateICAOs[icao] = rank;

            if (_candidateICAOs.Count > 500000)
            {
                _candidateICAOs = _candidateICAOs.Where(pair => pair.Value > 1).ToDictionary(pair => pair.Key, pair => pair.Value - 1);
            }

            return rank >= _confidenceLevel;
        }

        public void ProcessSample(int mag)
        {
            _ticks++;

            if (_ticks % (10 * OneSecond) == 0) // Happens every 10sec
            {
                var timeoutTicks = _timeout * OneSecond;
                _icaos = _icaos.Where(pair => (int) (_ticks - pair.Value) < timeoutTicks).ToDictionary(pair => pair.Key, pair => pair.Value);
            }

            if (_reset)
            {
                _icaos.Clear();
                _candidateICAOs.Clear();
                _reset = false;
            }

            _candidate[_candidateHead] = mag;
            _candidateHead = (_candidateHead + 1) % _candidate.Length;

            if (IsPreambleValid())
            {
                ReadData();
            }
        }

        public void Reset()
        {
            _reset = true;
        }

        public static uint GetICAOAddress(byte[] frame)
        {
            uint icao;
            var df = (frame[0] >> 3) & 0x1f;
            if (df == 11 || df == 17 || df == 18)
            {
                icao = (uint) (frame[1] << 16) | (uint) (frame[2] << 8) | frame[3];
            }
            else
            {
                icao = df >= 16 ? GetLongFrameParity(frame) : GetShortFrameParity(frame);
                if (icao == 0)
                {
                    icao = (uint) (frame[1] << 16) | (uint) (frame[2] << 8) | frame[3];
                }
            }
            return icao;
        }

        private static uint GetLongFrameParity(byte[] frame)
        {
            var data = (uint)(frame[0] << 24) | (uint)(frame[1] << 16) | (uint)(frame[2] << 8) | frame[3];
            var data1 = (uint)(frame[4] << 24) | (uint)(frame[5] << 16) | (uint)(frame[6] << 8) | frame[7];
            var data2 = (uint)(frame[8] << 24) | (uint)(frame[9] << 16) | (uint)(frame[10] << 8);

            for (var i = 0; i < 88; i++)
            {
                if ((data & 0x80000000) != 0)
                {
                    data ^= Polynomial;
                }
                data <<= 1;
                if ((data1 & 0x80000000) != 0)
                {
                    data |= 1;
                }
                data1 <<= 1;
                if ((data2 & 0x80000000) != 0)
                {
                    data1 |= 1;
                }
                data2 <<= 1;
            }

            var result0 = (byte)(data >> 24);
            var result1 = (byte)((data >> 16) & 0xff);
            var result2 = (byte)((data >> 8) & 0xff);

            var sum = (uint) ((result0 ^ frame[11]) << 16) | (uint) ((result1 ^ frame[12]) << 8) | (uint)(result2 ^ frame[13]);
            
            return sum;
        }

        private static uint GetShortFrameParity(byte[] frame)
        {
            var data = (uint)(frame[0] << 24) | (uint)(frame[1] << 16) | (uint)(frame[2] << 8) | frame[3];
            for (var i = 0; i < 32; i++)
            {
                if ((data & 0x80000000) != 0)
                {
                    data ^= Polynomial;
                }
                data <<= 1;
            }

            var result0 = (byte)(data >> 24);
            var result1 = (byte)((data >> 16) & 0xff);
            var result2 = (byte)((data >> 8) & 0xff);

            var sum = (uint) ((result0 ^ frame[4]) << 16) | (uint) ((result1 ^ frame[5]) << 8) | (uint)(result2 ^ frame[6]);

            return sum;
        }
    }
}
 
