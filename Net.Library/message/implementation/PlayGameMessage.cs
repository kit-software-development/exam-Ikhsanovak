using System;

namespace Net.Library.message.implementation
{
    [Serializable]
    public struct PlayGameMessage : Message
    {
        public const string PlayingGameStatus = "Playing";
        public const string WinGameStatus = "Win";
        public const string LoseGameStatus = "Lose";

        public string GameStatus { get; }
        public int LeftPlayerPositionY { get; }
        public uint LeftPlayerScore { get; }

        public int RightPlayerPositionY { get; }
        public uint RightPlayerScore { get; }

        public int BallPositionX { get; }
        public int BallPositionY { get; }

        public PlayGameMessage(
            int leftPlayerPositionY,
            uint leftPlayerScore,
            int rightPlayerPositionY,
            uint rightPlayerScore,
            int ballPositionX,
            int ballPositionY,
            string gameStatus
        )
        {
            GameStatus = gameStatus;

            LeftPlayerPositionY = leftPlayerPositionY;
            LeftPlayerScore = leftPlayerScore;

            RightPlayerPositionY = rightPlayerPositionY;
            RightPlayerScore = rightPlayerScore;

            BallPositionX = ballPositionX;
            BallPositionY = ballPositionY;
        }
    }
}