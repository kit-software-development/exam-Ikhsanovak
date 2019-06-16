using System;
using System.Windows.Forms;
using System.Drawing;
using ClientApp.client;
using Net.Library.message.implementation;

namespace ClientApp.form
{
    public partial class GameFieldForm : Form
    {
        private const int LeftPosition = 1;
        private const int BoardMovement = 32; //смещение игровой доски по оси Y
        private const int BoardHeight = 64;      
        private const int TableHeight = 256;
        
        internal static PongClient client = new PongClient();

        private Form signInForm = new SignInForm();
        private Form aboutForm = new AboutForm();
        private Form winForm = new WinForm();
        private Form loseForm = new LoseForm();

        //Игрок слева
        private Panel leftBoard;
        private Label leftPlayerName;
        private Label leftPlayerScore;     
        private Label leftPlayerWins;

        //Игрок справа
        private Panel rightBoard;
        private Label rightPlayerName;
        private Label rightPlayerScore;
        private Label rightPlayerWins;

        private Panel ball;

        private uint myPosition = 0;

        private bool isKeyboardEnable;

        /*Инициализация*/
        internal GameFieldForm()
        {
            Application.ApplicationExit += OnExit;

            InitializeComponent();

            leftBoard = game_left_board;
            rightBoard = game_right_board;

            ball = game_ball;

            leftPlayerName = game_left_name_label;
            rightPlayerName = game_right_name_label;

            leftPlayerScore = game_left_score_label;
            rightPlayerScore = game_right_score_label;

            leftPlayerWins = game_left_wins_label;
            rightPlayerWins = game_right_wins_label;
            
            //Подписка на события клиента:
            client.OnJoin += (message) => this.UI(() => OnJoinGame(message));
            client.OnStart += () => this.UI(OnStartGame);
            client.OnUpdate += (message) => this.UI(() => OnUpdateGame(message));
            client.OnWin += () => this.UI(OnWin);
            client.OnLose += () => this.UI(OnLose);
        }

        private void OnExit(object sender, EventArgs e) =>
            client.Stop();

        private void OnSignInClick(object sender, EventArgs e)
        {
            signInForm.Hide();
            signInForm.Show();
        }

        //Присоединение к игре
        private void OnJoinGame(JoinGameMessage? message)
        {
            if (message == null)
            {
                //Если присоединение не удалось, то открываем окно регистрации:
                signInForm.Hide();
                signInForm.Show();
                return;
            }
            PreparePlayers(message.Value);
            PlaceGameObjects();
        }

        private void PreparePlayers(JoinGameMessage messageValue)
        {
            //Проверка позиции:
            uint? inputMyPosition = messageValue.MyPosition;
            if (inputMyPosition == null)
            {
                //Если присоединение не удалось, то открываем окно регистрации:
                signInForm.Hide();
                signInForm.Show();
                return;
            }

            //Определяем цвета игровых досок:
            Color myColor = Color.FromArgb(0, 191, 255);
            Color enemyColor = Color.FromArgb(128, 128, 255);

            //Получение имен игроков:
            string inputEnemyName ="";
            if (messageValue.EnemyName == null)
            {
                inputEnemyName = "Ожидание противника";
            }
            else
            {
                inputEnemyName = messageValue.EnemyName;
            }
            uint inputEnemyWins = messageValue.EnemyWins;
            string inputMyName = messageValue.MyName;
            uint inputMyWins = messageValue.MyWins;

            //Определение позиции текущего игрока:
            myPosition = inputMyPosition.Value;
            if (myPosition == LeftPosition)
            {
                //Расположение текущего игрока слева:
                leftBoard.BackColor = myColor;
                leftPlayerName.ForeColor = myColor;
                leftPlayerName.Text = inputMyName;
                leftPlayerScore.ForeColor = myColor;
                leftPlayerWins.ForeColor = myColor;
                leftPlayerWins.Text = inputMyWins.ToString();

                //Расположение противника справа:
                rightBoard.BackColor = enemyColor;
                rightPlayerName.ForeColor = enemyColor;
                rightPlayerName.Text = inputEnemyName;
                rightPlayerScore.ForeColor = enemyColor;
                rightPlayerWins.ForeColor = enemyColor;
                rightPlayerWins.Text = inputEnemyWins.ToString();
            }
            else
            {
                //Расположение текущего игрока справа:
                rightBoard.BackColor = myColor;
                rightPlayerName.ForeColor = myColor;
                rightPlayerName.Text = inputMyName;
                rightPlayerScore.ForeColor = myColor;
                rightPlayerWins.ForeColor = myColor;
                rightPlayerWins.Text = inputMyWins.ToString();

                //Расположение противника слева:
                leftBoard.BackColor = enemyColor;
                leftPlayerName.ForeColor = enemyColor;
                leftPlayerName.Text = inputEnemyName;
                leftPlayerScore.ForeColor = enemyColor;
                leftPlayerWins.ForeColor = enemyColor;
                leftPlayerWins.Text = inputEnemyWins.ToString();
            }
        }

        private void PlaceGameObjects()
        {
            //Установка положения мяча:
            ball.Location = new Point(240, 112);

            //Установка положения игроков:
            leftBoard.Location = new Point(32, 96);
            rightBoard.Location = new Point(448, 96);

            //Установка счета:
            leftPlayerScore.Text = "0/5";           
            rightPlayerScore.Text = "0/5";
        }

        private void OnStartGame()
        {
            isKeyboardEnable = true;
        }

        private void OnUpdateGame(PlayGameMessage playGameMessage)
        {
            //Проверка доступности клавиатуры:
            if (!isKeyboardEnable)
            {
                return;
            }

            //Обновление позиции мяча:
            ball.Top = TableHeight - playGameMessage.BallPositionY;
            ball.Left = playGameMessage.BallPositionX;

            //Обновление позиции игроков:
            leftBoard.Top = TableHeight - playGameMessage.LeftPlayerPositionY;
            rightBoard.Top = TableHeight - playGameMessage.RightPlayerPositionY;

            //Обновление счета:
            leftPlayerScore.Text = playGameMessage.LeftPlayerScore + "/5";
            rightPlayerScore.Text = playGameMessage.RightPlayerScore + "/5";
        }
        
        private void OnKeyPressed(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            switch (key)
            {
                case 'w':
                case 'q':
                    MoveUp();
                    break;
                case 's':
                case 'a':
                    MoveDown();
                    break;
            }
        }

        private void MoveUp()
        {
            int boardY;
            if (myPosition == LeftPosition)
            {
                boardY = leftBoard.Top;
            }
            else
            {
                boardY = rightBoard.Top;
            }
            if (boardY - BoardMovement >= 0)
            {
                client.SendUpCommand();
            }
        }

        private void MoveDown()
        {
            int boardY;
            if (myPosition == LeftPosition)
            {
                boardY = leftBoard.Top;
            }
            else
            {
                boardY = rightBoard.Top;                
            }
            if (boardY + BoardHeight + BoardMovement <= TableHeight)
            {
                client.SendDownCommand();
            }
        }

        private void OnLose()
        {
            loseForm.Show();
        }

        private void OnWin()
        {
            winForm.Show();
        }

        private void OnAboutClick(object sender, EventArgs e)
        {
            aboutForm.Hide();
            aboutForm.Show();
        }
    }
}