using System;

namespace Net.Library.message.implementation
{
    [Serializable]
    public struct JoinGameMessage : Message
    {
        public uint? MyPosition { get; }
        public string MyName { get; }
        public uint MyWins { get;  }
        public string EnemyName { get; }
        public uint EnemyWins { get;  }

        public JoinGameMessage(uint? myPosition, string myName, uint myWins, string enemyName, uint enemyWins)
        {
            MyPosition = myPosition;
            MyName = myName;
            MyWins = myWins;
            EnemyName = enemyName;
            EnemyWins = enemyWins;
        }

        public override string ToString()
        {
            return "MyPosition: " + MyPosition +
                   " MyName: " + MyName +
                   " EnemyName: " + EnemyName;
        }
    }
}
