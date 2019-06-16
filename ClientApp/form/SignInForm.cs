using System;
using System.Windows.Forms;
using ClientApp.client;

namespace ClientApp.form
{
    public partial class SignInForm : Form
    {
        private TextBox playerNameTextBox;
        private Label errorLabel;
        private Button connectButton;

        internal SignInForm()
        {
            InitializeComponent();
            playerNameTextBox = sign_in_player_name_text_box;
            errorLabel = sign_in_error_label;
            connectButton = sign_in_connect_button;

            //Подписка на события клиента:
            PongClient client = GameFieldForm.client;
            client.OnConnect += OnConnect;
        }
        
        private void OnSignInClicked(object sender, EventArgs eventArgs)
        {
            errorLabel.Hide();

            //Проверка имени игрока:
            var playerName = CheckPlayerName();
            if (playerName == null)
            {
                return;
            }

            connectButton.Hide();

            //Подключение к игре
            var client = GameFieldForm.client;
            client.Connect(playerName); //в PongClient
        }

        private string CheckPlayerName()
        {
            var inputText = playerNameTextBox.Text;
            if (inputText.Length == 0)
            {
                errorLabel.Text = "Имя игрока не заполнено";
                errorLabel.Show();
                return null;
            }
            return inputText;
        }

        private void OnConnect(object sender, PongClient.ResponseTypeArg e)
        {
            connectButton.Show();
            
            switch (e.Type)
            {
                case ResponseType.ALREADY_CONNECTED:
                case ResponseType.SUCCESS:
                    //Если подключение было успешным, то переходим на поле игры
                    Hide();
                    break;
                //Иначе ошибка:
                case ResponseType.BAD_RESPONSE:
                    errorLabel.Text = "Сервис недоступен. Повторите попытку позже";
                    errorLabel.Show();
                    break;
                case ResponseType.NO_CONNECTION:
                    errorLabel.Text = "Отсутствует соединение с интернетом";
                    errorLabel.Show();
                    break;
            }
        }       
    }
}