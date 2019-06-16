using System;
using Server.gameSession.session.player;

namespace Server.gameSession.session.ball
{
    internal sealed class Ball
    {
        internal const int Radius = 16;
        private const int InitialPositionByX = 240;
        private const int InitialPositionByY = 112 + Radius;

        private const int InitialVelosityByX = 2;
        private const int ReflectVelosityByYCoefficient = 4;

        internal int PositionByX { get; set; }
        internal int PositionByY { get; set; }

        private int velocityByX;
        private int velocityByY;

        internal Ball()
        {
            PositionByX = InitialPositionByX;
            PositionByY = InitialPositionByY;

            //Установка направления по оси Х
            int randomDx = GetRandomDirection();
            velocityByX = InitialVelosityByX * randomDx;
            velocityByY = 0;
        }

        private static int GetRandomDirection()
        {
            Random random = new Random();
            const int Left = 1;
            const int Right = 2;
            int leftOrRight = random.Next(Left, Right + 1);
            int dx = 1;
            if (leftOrRight == Left)
            {
                dx = -1;
            }
            return dx;
        }
        
        internal void Move(int leftBoardY, int rightBoardY)
        {
            Reflection(leftBoardY, rightBoardY);
            ApplyVelocity();
        }

        private void Reflection(int leftBoardY, int rightBoardY)
        {
            //Верх и низ:
            if (PositionByY >= OnlineGameSession.TableHeight)
            {
                velocityByY *= -1;
            }
            if (PositionByY - 2 * Radius <= 0)
            {
                velocityByY *= -1;
            }

            //Центр мяча:
            int ballCenterY = PositionByY - Radius;

            //Отражение от игровой доски:
            const int BoardHeight = Player.BoardHeight;
            const int HalfBoardHeight = BoardHeight / 2;

            //Левая досочка:
            bool isReachedLeftBoardPositionByX = PositionByX <= Player.LeftPosition + Player.BoardWidth;
            bool intoLeftBoardBoundsByY = PositionByY < leftBoardY + 2 * Radius &&
                                         PositionByY > leftBoardY - BoardHeight;
            if (isReachedLeftBoardPositionByX && intoLeftBoardBoundsByY)
            {
                //Центр левой досочки:
                int leftBoardCenterY = leftBoardY - HalfBoardHeight;

                //Расстояние по Y между центром мяча и центром левой досочки
                int distanceByY = ballCenterY - leftBoardCenterY;
                velocityByY = distanceByY / ReflectVelosityByYCoefficient;
                velocityByX *= -1;
            }

            //Правая досочка:           
            bool isReachedRightBoardPositionByX = PositionByX + 2 * Radius >= Player.RightPosition;
            bool intoRightBoardBoundsByY = PositionByY < rightBoardY + 2 * Radius &&
                                          PositionByY > rightBoardY - BoardHeight;
            if (isReachedRightBoardPositionByX && intoRightBoardBoundsByY)
            {
                //Центр правой досочки:
                int rightBoardCenterY = rightBoardY - HalfBoardHeight;

                //Расстояние по Y между центром мяча и центром правой досочки
                int distanceByY = ballCenterY - rightBoardCenterY;
                velocityByY = distanceByY / ReflectVelosityByYCoefficient;
                velocityByX *= -1;
            }
        }

        private void ApplyVelocity()
        {
            PositionByX += velocityByX;
            PositionByY += velocityByY;
        }
    }
}