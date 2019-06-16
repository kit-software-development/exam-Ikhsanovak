using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Net.Library.connection
{
    public class IncomingConnectionEventArgs : EventArgs
    {
        public TcpConnection Connection { get; internal set; }
    }

    public class TcpConnectionListener
    {
        private readonly Thread thread;
        private readonly TcpListener listener;

        public event EventHandler<IncomingConnectionEventArgs> IncomingConnection;

        public TcpConnectionListener(IPAddress address, int port)
        {
            listener = new TcpListener(address, port);
            thread = new Thread(Listen)
            {
                IsBackground = true
            };
        }

        private void Listen()
        {
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                var connection = new TcpConnection(client);
                var args = new IncomingConnectionEventArgs
                {
                    Connection = connection
                };
                IncomingConnection?.Invoke(this, args);
            }
        }

        public void Start()
        {
            listener.Start();
            thread.Start();
        }

        public void Stop()
        {
            if (thread.IsAlive)
            {
                thread.Abort();
            }
            listener.Stop();
        }
    }
}