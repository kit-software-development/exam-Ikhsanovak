using System;
using System.Net.Sockets;
using Net.Library.message;
using Net.Library.util;

namespace Net.Library.connection
{
    public class TcpConnection : IDisposable
    {
        public event EventHandler<TcpConnectionArgs> OnDisconnect;

        public sealed class TcpConnectionArgs : EventArgs
        {
            public TcpConnection Connection { get; internal set; }
        }

        public TcpClient Client { get; }

        public TcpConnection(TcpClient client)
        {
            Client = client;
        }

        public void Send(Message message)
        {
            try
            {
                if (!this.Client.Connected)
                {
                    var connection = new TcpConnection(Client);
                    var args = new TcpConnectionArgs
                    {
                        Connection = connection
                    };
                    OnDisconnect?.Invoke(this, args);
                    return;
                }
                this.Client.Send(message);
            }
            catch (Exception)
            {
                var connection = new TcpConnection(Client);
                var args = new TcpConnectionArgs
                {
                    Connection = connection
                };
                OnDisconnect?.Invoke(this, args);
                return;
            }
        }

        public T Read<T>() where T : Message
        {
            try
            {
                if (!Client.Connected)
                {
                    var connection = new TcpConnection(Client);
                    var args = new TcpConnectionArgs
                    {
                        Connection = connection
                    };
                    OnDisconnect?.Invoke(this, args);
                    return default(T);
                }
                var stream = Client.GetStream();
                if (stream.DataAvailable)
                {
                    return stream.Read<T>();
                }
            }
            catch (Exception)
            {
                var connection = new TcpConnection(Client);
                var args = new TcpConnectionArgs
                {
                    Connection = connection
                };
                OnDisconnect?.Invoke(this, args);
            }
            return default(T);
        }

        public void Dispose()
        {
            if (Client.Connected)
            {
                Client.Close();
            }
        }
    }
}
