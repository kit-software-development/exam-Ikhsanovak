using System;
using System.Net;
using System.Net.Sockets;
using ClientApp.client.listener;
using Net.Library.message.implementation;
using Net.Library.util;

namespace ClientApp.client
{
    internal sealed class PongClient
    {
        private TcpClient tcpClient;

        private ClientListener<JoinGameMessage> joinGameListener;
        private ClientListener<PlayGameMessage> playGameListener;

        public class ResponseTypeArg : EventArgs
        {
            public ResponseType Type { get; internal set; }
        }
        //Событие присоединения
        internal event EventHandler<ResponseTypeArg> OnConnect;

        internal void Connect(string playerName)
        {
            //Если уже подключен
            if (tcpClient != null && tcpClient.Connected)
            {
                var args = new ResponseTypeArg
                {
                    Type = ResponseType.ALREADY_CONNECTED
                };
                OnConnect?.Invoke(this, args);
                return;
            }
            
            TcpClient client = new TcpClient();
            tcpClient = client;

            //Инициализация клиента - присоединение к игре:
            joinGameListener = new ClientListener<JoinGameMessage>(client);
            joinGameListener.OnMessageReceived += OnJoinGameResult;

            //Инициализация клиента - игровой процесс:
            playGameListener = new ClientListener<PlayGameMessage>(client);
            playGameListener.OnMessageReceived += OnUpdateGameResult;
            
            try
            {
                tcpClient.Connect(IPAddress.Loopback, 8080);
                //Успешное подключение
                if (tcpClient.Connected)
                {
                    var args = new ResponseTypeArg
                    {
                        Type = ResponseType.SUCCESS
                    };
                    OnConnect?.Invoke(this, args);

                    //Присоединение к игре
                    JoinGame(playerName);
                }
            }
            catch (SocketException)
            {
                var args = new ResponseTypeArg
                {
                    Type = ResponseType.NO_CONNECTION
                };
                OnConnect?.Invoke(this, args);
            }
        }

        private void OnJoinGameResult(object sender, ClientListener<JoinGameMessage>.TArg e)
        {
            //Получение позиции игрока в игре
            uint? myPlayerPosition = e.Arg.MyPosition;

            //Проверка позиции игрока
            if (myPlayerPosition == null)
            {
                //Если присоединение не удалось, то разрываем соединение
                OnJoin?.Invoke(null);
                tcpClient.Dispose();
                return;
            }

            //Если присоединение успешно      
            OnJoin?.Invoke(e.Arg);

            //Если есть противник, то начинаем игру
            if (e.Arg.EnemyName != null)
            {
                joinGameListener.Stop();
                OnStart?.Invoke();
                playGameListener.Start();
            }
        }

        //Событие подключения к игре
        internal event Action<JoinGameMessage?> OnJoin;

        private void JoinGame(string playerName)
        {
            if (!tcpClient.Connected)
            {
                OnJoin?.Invoke(null);
                return;
            }
            try
            {
                //Отправка имени игрока:
                TextMessage textMessage = new TextMessage(playerName);
                tcpClient.Send(textMessage);               
                joinGameListener.Start();
            }
            catch (Exception)
            {
                OnJoin?.Invoke(null);
            }
        }
        
        //События игры
        internal event Action OnStart;
        internal event Action<PlayGameMessage> OnUpdate;
        internal event Action OnWin;
        internal event Action OnLose;
        
        internal void SendDownCommand()
        {
            SendCommand("Down");
        }

        internal void SendUpCommand()
        {
            SendCommand("Up");
        }

        private void SendCommand(string command)
        {
            if (tcpClient.Connected)
            {
                TextMessage textMessage = new TextMessage(command);
                tcpClient.Send(textMessage);
            }
        }

        private void OnUpdateGameResult(object sender, ClientListener<PlayGameMessage>.TArg e)
        {
            //Проверка статуса игры:
            string status = e.Arg.GameStatus;
            switch (status)
            {
                case PlayGameMessage.PlayingGameStatus:
                    OnUpdate?.Invoke(e.Arg);
                    break;
                case PlayGameMessage.WinGameStatus:
                    tcpClient.Dispose();
                    playGameListener.Stop();
                    OnWin?.Invoke();
                    break;
                case PlayGameMessage.LoseGameStatus:
                    tcpClient.Dispose();
                    playGameListener.Stop();
                    OnLose?.Invoke();
                    break;
            }
        }

        internal void Stop()
        {
            tcpClient?.Dispose();
            joinGameListener?.Stop();
            playGameListener?.Stop();
        }
    }
}