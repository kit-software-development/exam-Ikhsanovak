using System;
using System.Threading;
using Net.Library.connection;
using Net.Library.message;
using Net.Library.message.implementation;
using Server.core;
using Server.repository;

namespace Server.gameSession.session.player
{
    internal sealed class Player
    {
        internal const uint LeftPlayer = 1;
        internal const uint RightPlayer = 2;

        internal const int BoardMovement = 32;
        internal const int BoardHeight = 64;
        internal const int BoardWidth = 32;

        private const int InitialPlayerPositionByY = 96 + BoardHeight;
        internal const int LeftPosition = 32;
        internal const int RightPosition = 448;

        internal uint Number { get; }
        internal int PositionByY { get; set; }
        internal int PositionByX { get; }
        internal uint Score { get; set; }

        internal event EventHandler<PlayerArg> OnDisconnectEvent;

        public class PlayerArg : EventArgs
        {
            public Player Player { get; internal set; }
        }

        private TcpConnection Connection { get; }
        private readonly Thread listenThread;
        
        internal Account Account { get; }

        internal Player(Account account, uint playerNumber, TcpConnection connection)
        {
            Account = account;
            Number = playerNumber;
            Score = 0;
            
            PositionByY = InitialPlayerPositionByY;

            //Устанавливаем позицию игрока по Х
            if (Number == LeftPlayer)
            {
                PositionByX = LeftPosition;
            }
            else
            {
                PositionByX = RightPosition;
            }

            Connection = connection;
            Connection.OnDisconnect += OnDisconnect;
            
            listenThread = new Thread(ListenCommand)
            {
                IsBackground = true
            };
        }

        internal void Start()
        {
            listenThread.Start();
        }

        internal void FinishAsWinner()
        {
            PongServerApplication application = PongServerApplication.Get();
            AccountRepository repository = application.AccountRepository;
            repository.AddWin(Account);
            
            SendFinishMessage(PlayGameMessage.WinGameStatus);
        }

        internal void FinishAsLoser()
        {
            SendFinishMessage(PlayGameMessage.LoseGameStatus);
        }

        internal bool IsLeftPlayer()
        {
            return Number == LeftPlayer;
        }

        internal bool IsRightPlayer()
        {
            return Number == RightPlayer;
        }

        private void SendFinishMessage(string finishStatus)
        {
            PlayGameMessage message = new PlayGameMessage(0, 0, 0, 0, 0, 0, finishStatus);
            Connection.Send(message);
            Connection.Dispose();
            listenThread.Abort();
        }

        public void Send(Message message)
        {
            Connection.Send(message);
        }

        private void OnDisconnect(object sender, TcpConnection.TcpConnectionArgs e)
        {
            Player player = new Player(Account, Number, e.Connection);
            var args = new PlayerArg
            {
                Player = player
            };
            OnDisconnectEvent?.Invoke(this, args);
        }

        //Прослушивание команд: вверх или вниз
        private void ListenCommand()
        {
            while (true)
            {
                TextMessage textMessage = Connection.Read<TextMessage>();
                string command = textMessage.ToString();

                //Блокировка потока
                Monitor.Enter(this);
                switch (command)
                {
                    case "Up":
                        if (PositionByY + BoardMovement <= OnlineGameSession.TableHeight)
                        {
                            PositionByY += BoardMovement;
                        }
                        break;
                    case "Down":
                        if (PositionByY - BoardMovement - BoardHeight >= 0)
                        {
                            PositionByY -= BoardMovement;
                        }
                        break;
                }
                Monitor.Exit(this);
            }
        }
    }
}