using System;
using System.Threading;
using Net.Library.connection;
using Net.Library.message.implementation;
using Server.gameSession.session.ball;
using Server.gameSession.session.player;
using Server.repository;

namespace Server.gameSession.session
{
    internal sealed class OnlineGameSession
    {
        internal enum Status
        {
            JOINING,
            PLAYING
        }

        private const uint WinScore = 5;
        internal const int TableHeight = 256;
        internal const int TableWidth = 512;

        private Thread gameThread;

        private Status status = Status.JOINING;

        private Player onlineLeftPlayer;
        private Player onlineRightPlayer;

        private Ball ball;

        internal void AddPlayer(Account account, TcpConnection inputConnection)
        {
            if (status != Status.JOINING)
            {
                JoinGameMessage joinPlayerMessage = new JoinGameMessage(
                    null,
                    null,
                    default(uint),
                    null,
                    default(uint)
                );
                inputConnection.Send(joinPlayerMessage);
                return;
            }

            //Check for already joining:
            if (onlineLeftPlayer != null && onlineLeftPlayer.Account == account)
            {
                return;
            }

            if (onlineRightPlayer != null && onlineRightPlayer.Account == account)
            {
                return;
            }

            //Проверка позиции игрока слева
            if (onlineLeftPlayer == null)
            {
                //Создание игрока слева
                onlineLeftPlayer = new Player(account, Player.LeftPlayer, inputConnection);
                onlineLeftPlayer.OnDisconnectEvent += OnDisconnect; //OnDisconnectEvent в Player

                //Отправка сообщения для игрока слева
                JoinGameMessage joinPlayerMessageForLeftPlayer = new JoinGameMessage(
                    Player.LeftPlayer,
                    account.Name,
                    account.Wins,
                    null,
                    default(uint)
                );
                onlineLeftPlayer.Send(joinPlayerMessageForLeftPlayer);
                return;
            }

            //Проверка позиции игрока справа
            if (onlineRightPlayer == null)
            {
                //Создание игрока справа
                onlineRightPlayer = new Player(account, Player.RightPlayer, inputConnection);
                onlineRightPlayer.OnDisconnectEvent += OnDisconnect; //OnDisconnectEvent в Player

                //Отправка сообщения для игрока справа
                JoinGameMessage joinPlayerMessageForRightPlayer = new JoinGameMessage(
                    Player.RightPlayer,
                    account.Name,
                    account.Wins,
                    onlineLeftPlayer.Account.Name,
                    onlineLeftPlayer.Account.Wins
                );
                onlineRightPlayer.Send(joinPlayerMessageForRightPlayer);

                //Отправка сообщения для игрока слева (сообщение, что появился противник)
                JoinGameMessage joinPlayerMessageForLeftPlayer = new JoinGameMessage(
                    Player.LeftPlayer,
                    onlineLeftPlayer.Account.Name,
                    onlineLeftPlayer.Account.Wins,
                    account.Name,
                    account.Wins
                );
                onlineLeftPlayer.Send(joinPlayerMessageForLeftPlayer);

                //Запуск игры
                Start();
            }
        }

        private void Start()
        {
            status = Status.PLAYING;
            gameThread = new Thread(GameUpdate)
            {
                IsBackground = true
            };
            
            ball = new Ball();
            
            gameThread.Start();
            
            onlineLeftPlayer.Start();
            onlineRightPlayer.Start();
        }

        private void GameUpdate()
        {
            while (status == Status.PLAYING)
            {
                //Частота обновления игры
                Thread.Sleep(33);

                //Блокировка потока левого игрока для извлечения позиции по оси Y
                Monitor.Enter(onlineLeftPlayer);
                int leftBoardPositionY = onlineLeftPlayer.PositionByY;
                Monitor.Exit(onlineLeftPlayer);

                //Блокировка потока правого игрока для извлечения позиции по оси Y
                Monitor.Enter(onlineRightPlayer);
                int rightBoardPositionY = onlineRightPlayer.PositionByY;
                Monitor.Exit(onlineRightPlayer);

                ball.Move(leftBoardPositionY, rightBoardPositionY);

                //Проверка гола левому игроку
                if (WasLeftGoal())
                {
                    //Добавление очков правому игроку
                    Monitor.Enter(onlineRightPlayer);
                    Player player = onlineRightPlayer;
                    player.Score += 1;
                    bool isWin = IsWin(player);
                    Monitor.Exit(onlineRightPlayer);

                    Console.WriteLine("GOAL TO THE LEFT PLAYER!");

                    if (isWin)
                    {
                        //Победитель
                        Monitor.Enter(onlineRightPlayer);
                        onlineRightPlayer.FinishAsWinner();
                        Monitor.Exit(onlineRightPlayer);
                        Console.WriteLine("RIGHT PLAYER HAS WIN!");

                        //Проигравший
                        Monitor.Enter(onlineLeftPlayer);
                        onlineLeftPlayer.FinishAsLoser();
                        Monitor.Exit(onlineLeftPlayer);
                        Console.WriteLine("LEFT PLAYER HAS LOST!");

                        Finish();
                        break;
                    }
                    
                    ball = new Ball();
                }

                //Проверка гола правому игроку
                if (WasRightGoal())
                {
                    //Добавление очков правому игроку
                    Monitor.Enter(onlineLeftPlayer);
                    Player player = onlineLeftPlayer;
                    player.Score += 1;
                    bool isWin = IsWin(player);
                    Monitor.Exit(onlineLeftPlayer);

                    Console.WriteLine("GOAL TO THE RIGHT PLAYER!");
                    
                    if (isWin)
                    {
                        //Победитель
                        Monitor.Enter(onlineLeftPlayer);
                        onlineLeftPlayer.FinishAsWinner();
                        Monitor.Exit(onlineLeftPlayer);
                        Console.WriteLine("LEFT PLAYER HAS WIN!");

                        //Проигравший
                        Monitor.Enter(onlineRightPlayer);
                        onlineRightPlayer.FinishAsLoser();
                        Monitor.Exit(onlineRightPlayer);
                        Console.WriteLine("RIGHT PLAYER HAS LOST!");

                        Finish();
                        break;
                    }
                    
                    ball = new Ball();
                }

                //Сообщение об игре
                PlayGameMessage playGameMessage = new PlayGameMessage(
                    onlineLeftPlayer.PositionByY,
                    onlineLeftPlayer.Score,
                    onlineRightPlayer.PositionByY,
                    onlineRightPlayer.Score,
                    ball.PositionByX,
                    ball.PositionByY,
                    PlayGameMessage.PlayingGameStatus
                );

                //Отправка сообщения левому игроку
                Monitor.Enter(onlineLeftPlayer);
                onlineLeftPlayer.Send(playGameMessage);
                Monitor.Exit(onlineLeftPlayer);

                //Отправка сообщения правому игроку
                Monitor.Enter(onlineRightPlayer);
                this.onlineRightPlayer.Send(playGameMessage);
                Monitor.Exit(onlineRightPlayer);
            }
        }

        private bool WasLeftGoal()
        {
            return ball.PositionByX <= 0;
        }

        private bool WasRightGoal()
        {
            return ball.PositionByX + 2 * Ball.Radius >= TableWidth;
        }

        private static bool IsWin(Player winnerRoundPlayer)
        {
            return winnerRoundPlayer.Score == 5; //если игрок набрал 5 побед в игре, то он победил
        }

        private void Finish()
        {
            ball = null;
            
            onlineLeftPlayer = null;
            onlineRightPlayer = null;
            
            gameThread.Abort();

            status = Status.JOINING;
        }

        private void OnDisconnect(object sender, Player.PlayerArg e)
        {
            var disconnectedPlayer = e.Player;
            if (disconnectedPlayer.IsLeftPlayer())
            {
                Console.WriteLine("LEFT PLAYER HAS DISCONNECTED!");

                //Установка статуса победителя для правого игрока
                Monitor.Enter(onlineRightPlayer);
                onlineRightPlayer.FinishAsWinner();
                Monitor.Exit(onlineRightPlayer);
                this.Finish();
            }

            if (disconnectedPlayer.IsRightPlayer())
            {
                Console.WriteLine("RIGHT PLAYER HAS DISCONNECTED!");

                //Установка статуса победителя для левого игрока
                Monitor.Enter(onlineLeftPlayer);
                onlineLeftPlayer.FinishAsWinner();
                Monitor.Exit(onlineLeftPlayer);
                Finish();
            }
        }
    }
}