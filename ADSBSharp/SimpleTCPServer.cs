using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace ADSBSharp
{
    public class SimpleTcpServer : IFrameSink,IDisposable
    {
        private const int DefaultPortNumber = 47806;

        private TcpListener _listener;
        private int _port = DefaultPortNumber;
        private Thread _listenerThread;
        private bool _listenerThreadRunning;

        private readonly Queue<string> _frameQueue = new Queue<string>();
        private readonly AutoResetEvent _frameEvent = new AutoResetEvent(false);
        private readonly AutoResetEvent _clientConnectedEvent = new AutoResetEvent(false);
        private readonly List<TcpClient> _tcpClients = new List<TcpClient>();
        private readonly List<TcpClient> _deadTcpClients = new List<TcpClient>();

        ~SimpleTcpServer()
        {
            Dispose();
        }

        public void Dispose()
        {
            Stop();
            GC.SuppressFinalize(this);
        }
        
        #region Public Methods

        public void FrameReady(byte[] frame, int actualLength)
        {
            lock (_frameQueue)
            {
                if (_frameQueue.Count > 1000)
                {
                    return;
                }
            }

            var sb = new StringBuilder();
            sb.Append("*");
            for (var i = 0; i < actualLength; i++)
            {
                sb.Append(string.Format("{0:X2}", frame[i]));
            }
            sb.Append(";\r\n");

            lock (_frameQueue)
            {
                _frameQueue.Enqueue(sb.ToString());
            }
            _frameEvent.Set();
        }

        public void Start(string hostName, int port)
        {
            if (_listenerThread == null)
            {
                _port = port;


                #region Listen / Async Accept

                try
                {
                    _listener = new TcpListener(IPAddress.Any, _port);
                    _listener.Start();
                    _listener.BeginAcceptTcpClient(TcpClientConnectCallback, _listener);
                    Console.WriteLine("Listening on {0}", _listener.LocalEndpoint);
                }
                catch
                {
                    if (_listener != null)
                    {
                        _listener.Stop();
                        _listener = null;
                    }
                    throw;
                }

                #endregion

                _listenerThread = new Thread(ListenerThread);
                _frameEvent.Reset();
                _clientConnectedEvent.Reset();
                _listenerThreadRunning = true;
                _listenerThread.Start();
            }
        }

        public void Stop()
        {
            _listenerThreadRunning = false;
            if (_listenerThread != null)
            {
                _frameEvent.Set();
                _clientConnectedEvent.Set();
                _listenerThread.Join();
                _listenerThread = null;
            }
        }

        #endregion

        #region Private Methods

        private void ListenerThread()
        {
            var encoder = new ASCIIEncoding();

            while (_listenerThreadRunning)
            {
                if (_tcpClients.Count == 0)
                {
                    _clientConnectedEvent.WaitOne();
                }
                _frameEvent.WaitOne();

                string frameString;
                lock (_frameQueue)
                {
                    if (_frameQueue.Count == 0)
                    {
                        continue;
                    }
                    frameString = _frameQueue.Dequeue();
                }

                var bytes = encoder.GetBytes(frameString);
                lock (_tcpClients)
                {
                    foreach (TcpClient client in _tcpClients)
                    {
                        try
                        {
                            if (client.Connected)
                            {
                                var stream = client.GetStream();
                                stream.Write(bytes, 0, bytes.Length);
                                stream.Flush();
                            }
                            else
                            {
                                _deadTcpClients.Add(client);
                            }
                        }
                        catch
                        {
                            _deadTcpClients.Add(client);
                        }
                    }
                }
                if (_deadTcpClients.Count > 0)
                {
                    CloseDead();
                }
            }

            CloseAll();

            try
            {
                _listener.Stop();
            }
            catch
            {
            }

            _listenerThreadRunning = false;
            Console.WriteLine("TCP Server loop exited...");
        }

        private void CloseDead()
        {
            lock (_tcpClients)
            {
                foreach (TcpClient client in _deadTcpClients)
                {
                    try
                    {
                        Console.WriteLine("Removing client from {0}", client.Client.RemoteEndPoint);
                        if (client.Connected)
                        {
                            var stream = client.GetStream();
                            stream.Close();
                        }
                        client.Close();
                    }
                    catch
                    {
                    }
                    _tcpClients.Remove(client);
                }
            }
            _deadTcpClients.Clear();
        }

        private void CloseAll()
        {
            lock (_tcpClients)
            {
                foreach (TcpClient client in _tcpClients)
                {
                    try
                    {
                        if (client.Connected)
                        {
                            var stream = client.GetStream();
                            stream.Close();
                        }
                        client.Close();
                    }
                    catch
                    {
                    }
                }
                _tcpClients.Clear();
            }
        }

        #endregion

        #region Async Callback

        private void TcpClientConnectCallback(IAsyncResult result)
        {
            if (_listenerThreadRunning)
            {
                var listener = (TcpListener)result.AsyncState;
                var client = listener.EndAcceptTcpClient(result);
                lock (_tcpClients)
                {
                    _tcpClients.Add(client);
                }
                _clientConnectedEvent.Set();

                Console.WriteLine("New client from {0}. {1} clients now connected.", client.Client.RemoteEndPoint, _tcpClients.Count);

                try
                {
                    _listener.BeginAcceptTcpClient(TcpClientConnectCallback, _listener);
                }
                catch
                {
                    //Console.WriteLine("Terminating TCP Server");
                    Stop();
                }
            }
        }

        #endregion
    }
}
