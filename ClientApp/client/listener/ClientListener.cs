using System;
using System.Net.Sockets;
using System.Threading;
using Net.Library.message;
using Net.Library.util;

namespace ClientApp.client.listener
{
    internal class ClientListener<T> where T : Message
    {
        internal event EventHandler<TArg> OnMessageReceived;

        public class TArg : EventArgs
        {
            public T Arg { get; internal set; }
        }

        private TcpClient tcpClient;
        private Thread thread;      
        private bool isCancel;
        
        internal ClientListener(TcpClient client)
        {
            tcpClient = client;
        }

        internal void Start()
        {
            isCancel = false;
            thread = new Thread(Listen);
            thread.Start();
        }

        private void Listen()
        {
            while (true)
            {
                T result = Update();
                if (isCancel)
                {
                    return;
                }
                var args = new TArg
                {
                    Arg = result
                };
                OnMessageReceived?.Invoke(this, args);
            }
        }

        private T Update()
        {
            T message = default(T);
            while (true)
            {
                if (isCancel)
                {
                    break;
                }
                NetworkStream networkStream = tcpClient.GetStream();
                if (networkStream.DataAvailable)
                {
                    message = networkStream.Read<T>();
                    break;
                }
            }
            return message;
        }

        internal void Stop() => isCancel = true;
    }
}