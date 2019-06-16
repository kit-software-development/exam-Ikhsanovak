using System.Collections.Generic;
using System.Net;
using Net.Library.connection;
using Server.core;
using Server.gameSession.session;
using Server.gameSession.task;

namespace Server.manager.implementation.accountConnection
{
    internal class AccountConnectionManager
    {
        protected PongServerApplication application;

        private readonly TcpConnectionListener tcpListener;

        private OnlineGameSession gameSession;

        private HashSet<OnlinePlayerJoiningTask> joinTasks = new HashSet<OnlinePlayerJoiningTask>();

        internal AccountConnectionManager(PongServerApplication application)
        {
            this.application = application;
            tcpListener = new TcpConnectionListener(IPAddress.Any, 8080);
            tcpListener.IncomingConnection += OnIncomingConnection;
        }

        private void OnIncomingConnection(object sender, IncomingConnectionEventArgs e)
        {
            TcpConnection connection = e.Connection;
            ListenPlayerJoining(connection);
        }

        internal void ListenPlayerJoining(TcpConnection inputConnection)
        {
            OnlinePlayerJoiningTask joinGameTask = new OnlinePlayerJoiningTask(gameSession, inputConnection);
            joinGameTask.OnFinished += RemoveTask;
            joinTasks.Add(joinGameTask);
            joinGameTask.Start();
        }

        private void RemoveTask(object sender, OnlinePlayerJoiningTask.OnlinePlayerJoiningTaskArg e)
        {
            joinTasks.Remove(e.OnlinePlayerJoining);
        }

        internal  void OnStart()
        {
            tcpListener.Start();
            gameSession = new OnlineGameSession();
        }

        internal void OnStop()
        {
            tcpListener.Stop();

            gameSession = null;
            foreach (OnlinePlayerJoiningTask task in joinTasks)
            {
                task.OnFinished -= RemoveTask;
                task.Finish();
            }
            joinTasks.Clear();
        }
    }
}