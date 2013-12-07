using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace ADSBSharp
{
    public class AdsbHubClient: IFrameSink
    {          
        private const int MaxFramesInQueue = 500;
      
        private readonly Queue<string> _frameQueue = new Queue<string>();
        private readonly AutoResetEvent _frameEvent = new AutoResetEvent(false);        
        private Thread _clientThread;
        private bool _clientThreadRunning;
        private TcpClient _tcpClient = new TcpClient();
        private string _hostName;
        private int _port;

        public void FrameReady(byte[] frame, int actualLength)
        {
            lock (_frameQueue)
            {
                if (_frameQueue.Count >= MaxFramesInQueue)
                {
                    _frameQueue.Dequeue();
                }
                var sb = new StringBuilder(actualLength * 2 + 4);
                sb.Append("*");
                for (var i = 0; i < actualLength; i++)
                {
                    sb.Append(string.Format("{0:X2}", frame[i]));
                }
                sb.Append(";\r\n");
                _frameQueue.Enqueue(sb.ToString());
            }
            _frameEvent.Set();
        }


        public void Start(string hostName, int port)
        {
            _hostName = hostName;
            _port = port;
            if (_clientThread == null)
            {
                try
                {
                    _tcpClient = new TcpClient();
                    _tcpClient.Connect(_hostName, _port);
                }
                catch
                {
                    Console.WriteLine("whoopsie fix me");
                    throw;
                }

                _clientThread = new Thread(ClientThreadLoop);
                _clientThreadRunning = true;
                _clientThread.Start();
            }
        }

        public void Stop()
        {
            if (_clientThread != null)
            {
                _clientThreadRunning = false;
                _frameEvent.Set();
                _clientThread.Join();
                _clientThread = null;
            }
        }

        private void DisconnectClient()
        {
            try
            {
                _tcpClient.Client.Close(100);
                _tcpClient.Close();
            }
            catch
            {
                Console.WriteLine("The client is already closed.");
            }
        }

        private void ClientThreadLoop()
        {
            var encoder = new ASCIIEncoding();
            while (_clientThreadRunning)
            {
                if (_frameQueue.Count == 0)
                {
                    _frameEvent.WaitOne();
                    if (!_clientThreadRunning)
                        return;
                    if (_frameQueue.Count == 0)
                    {
                        continue;
                    }
                }

                string frameString;
                lock (_frameQueue)
                {
                    frameString = _frameQueue.Dequeue();
                }

                var bytes = encoder.GetBytes(frameString);

                while (_clientThreadRunning)
                {
                    try
                    {
                        var stream = _tcpClient.GetStream();
                        stream.Write(bytes, 0, bytes.Length);
                        break;
                    }
                    catch
                    {
                        DisconnectClient();
                        Thread.Sleep(1000);
                        try
                        {
                            _tcpClient = new TcpClient();
                            _tcpClient.Connect(_hostName, _port);
                        }
                        catch
                        {
                            Console.WriteLine("Reconnection attempt failed.");
                        }
                    }
                }
            }
            
            DisconnectClient();

            _clientThreadRunning = false;
        }
    }
}
