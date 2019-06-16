using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Net.Library.connection;
using Net.Library.message.implementation;
using Net.Library.util;
using Server.core;
using Server.gameSession.session;
using Server.repository;

namespace Server.gameSession.task
{
    internal sealed class OnlinePlayerJoiningTask
    {
        private OnlineGameSession targetGameSession;
        private TcpConnection inputConnection;
        private Thread playerJoiningThread;
        private bool isCountDownCancelled;

        //Событие завершения задания
        internal event EventHandler<OnlinePlayerJoiningTaskArg> OnFinished;

        public class OnlinePlayerJoiningTaskArg : EventArgs
        {
            public OnlinePlayerJoiningTask OnlinePlayerJoining { get; internal set; }
        }

        internal OnlinePlayerJoiningTask(OnlineGameSession session, TcpConnection inputConnection)
        {
            targetGameSession = session;
            this.inputConnection = inputConnection;

            //Поток для присоединения игрока
            playerJoiningThread = new Thread(ListenPlayerNameJoining)
            {
                IsBackground = true
            };
        }

        internal void Start()
        {
            playerJoiningThread.Start();
            
            TimeSpan timeSpan = TimeSpan.FromSeconds(5);
            
            Task
                .Delay(timeSpan)
                .ContinueWith(task =>
                {
                    if (!isCountDownCancelled)
                    {
                        Console.WriteLine("KILL JOIN THREAD");
                        Finish();
                    }
                });
        }

        private void ListenPlayerNameJoining()
        {
            TcpClient connectionClient = inputConnection.Client;
            
            bool isWainting = true;
            while (isWainting)
            {
                NetworkStream networkStream = connectionClient.GetStream();
                if (networkStream.DataAvailable)
                {
                    //Достаем имя игрока
                    TextMessage textMessage = networkStream.Read<TextMessage>();
                    string playerName = textMessage.ToString();

                    if (playerName.Length < 1)
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

                    //Достаем аккаунт из репозитория аккаунтов
                    PongServerApplication application = PongServerApplication.Get();
                    AccountRepository accountRepository = application.AccountRepository;
                    Account account = accountRepository.Fetch(playerName);

                    //Подключение к игре
                    targetGameSession.AddPlayer(account, inputConnection);

                    isWainting = false;
                }
            }           
            isCountDownCancelled = true;            
            Finish();
        }
        internal void Finish()
        {
            playerJoiningThread.Abort();
            OnlinePlayerJoiningTask onlinePlayerJoiningTask = new OnlinePlayerJoiningTask(targetGameSession, inputConnection);
            var args = new OnlinePlayerJoiningTaskArg
            {
                OnlinePlayerJoining = onlinePlayerJoiningTask
            };
            OnFinished?.Invoke(this, args);
        }
    }
}