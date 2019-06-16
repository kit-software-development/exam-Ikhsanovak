using System;
using Server.manager.implementation.accountConnection;
using Server.repository;

namespace Server.core
{
    internal sealed class PongServerApplication
    {
        private static PongServerApplication application;

        private PongServerApplication()
        { }

        //"Менеджер" для подключения к игре
        internal AccountConnectionManager AccountConnectionManager { get; private set; }

        //Хранение данных
        internal AccountRepository AccountRepository { get; } = new AccountRepository();

        internal static void Start()
        {
            if (application != null)
            {
                return;
            }
            application = new PongServerApplication();
            application.OnStart();

            Console.WriteLine("Pong Server Started.");
            Console.Read();

            application.OnStop();
        }

        private void OnStart()
        {
            //Получение данных о игроках
            AccountRepository.GetAccounts();
            
            //Инициализация и запуск "менеджера"
            AccountConnectionManager = new AccountConnectionManager(this);
            AccountConnectionManager.OnStart();
        }

        private void OnStop()
        {
            AccountConnectionManager.OnStop();
        }

        internal static PongServerApplication Get()
        {
            return application;
        }
    }
}