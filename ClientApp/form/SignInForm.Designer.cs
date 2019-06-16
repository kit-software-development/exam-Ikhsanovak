namespace ClientApp.form
{
    partial class SignInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sign_in_root = new System.Windows.Forms.Panel();
            this.sign_in_error_panel = new System.Windows.Forms.Panel();
            this.sign_in_error_label = new System.Windows.Forms.Label();
            this.sign_in_game_header_label = new System.Windows.Forms.Label();
            this.sign_in_player_name = new System.Windows.Forms.Label();
            this.sign_in_connect_button = new System.Windows.Forms.Button();
            this.sign_in_player_name_text_box = new System.Windows.Forms.TextBox();
            this.sign_in_root.SuspendLayout();
            this.sign_in_error_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sign_in_root
            // 
            this.sign_in_root.BackgroundImage = global::ClientApp.Properties.Resources.back;
            this.sign_in_root.Controls.Add(this.sign_in_error_panel);
            this.sign_in_root.Controls.Add(this.sign_in_game_header_label);
            this.sign_in_root.Controls.Add(this.sign_in_player_name);
            this.sign_in_root.Controls.Add(this.sign_in_connect_button);
            this.sign_in_root.Controls.Add(this.sign_in_player_name_text_box);
            this.sign_in_root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sign_in_root.Location = new System.Drawing.Point(0, 0);
            this.sign_in_root.Margin = new System.Windows.Forms.Padding(0);
            this.sign_in_root.Name = "sign_in_root";
            this.sign_in_root.Size = new System.Drawing.Size(368, 270);
            this.sign_in_root.TabIndex = 7;
            // 
            // sign_in_error_panel
            // 
            this.sign_in_error_panel.BackColor = System.Drawing.Color.Transparent;
            this.sign_in_error_panel.Controls.Add(this.sign_in_error_label);
            this.sign_in_error_panel.Location = new System.Drawing.Point(102, 142);
            this.sign_in_error_panel.Name = "sign_in_error_panel";
            this.sign_in_error_panel.Size = new System.Drawing.Size(157, 37);
            this.sign_in_error_panel.TabIndex = 5;
            // 
            // sign_in_error_label
            // 
            this.sign_in_error_label.AllowDrop = true;
            this.sign_in_error_label.BackColor = System.Drawing.Color.Transparent;
            this.sign_in_error_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sign_in_error_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(20)))), ((int)(((byte)(0)))));
            this.sign_in_error_label.Location = new System.Drawing.Point(0, 0);
            this.sign_in_error_label.Name = "sign_in_error_label";
            this.sign_in_error_label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sign_in_error_label.Size = new System.Drawing.Size(157, 37);
            this.sign_in_error_label.TabIndex = 4;
            this.sign_in_error_label.Text = "Поле не заполнено";
            this.sign_in_error_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sign_in_game_header_label
            // 
            this.sign_in_game_header_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.sign_in_game_header_label.AutoSize = true;
            this.sign_in_game_header_label.BackColor = System.Drawing.Color.Transparent;
            this.sign_in_game_header_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sign_in_game_header_label.Location = new System.Drawing.Point(128, 25);
            this.sign_in_game_header_label.Name = "sign_in_game_header_label";
            this.sign_in_game_header_label.Size = new System.Drawing.Size(106, 35);
            this.sign_in_game_header_label.TabIndex = 4;
            this.sign_in_game_header_label.Text = "PONG";
            // 
            // sign_in_player_name
            // 
            this.sign_in_player_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.sign_in_player_name.AutoSize = true;
            this.sign_in_player_name.BackColor = System.Drawing.Color.Transparent;
            this.sign_in_player_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sign_in_player_name.Location = new System.Drawing.Point(131, 78);
            this.sign_in_player_name.Name = "sign_in_player_name";
            this.sign_in_player_name.Size = new System.Drawing.Size(94, 16);
            this.sign_in_player_name.TabIndex = 2;
            this.sign_in_player_name.Text = " Введите имя";
            // 
            // sign_in_connect_button
            // 
            this.sign_in_connect_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.sign_in_connect_button.BackColor = System.Drawing.Color.White;
            this.sign_in_connect_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sign_in_connect_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sign_in_connect_button.Location = new System.Drawing.Point(120, 201);
            this.sign_in_connect_button.Name = "sign_in_connect_button";
            this.sign_in_connect_button.Size = new System.Drawing.Size(125, 33);
            this.sign_in_connect_button.TabIndex = 1;
            this.sign_in_connect_button.Text = "Подключиться к игре";
            this.sign_in_connect_button.UseMnemonic = false;
            this.sign_in_connect_button.UseVisualStyleBackColor = false;
            this.sign_in_connect_button.Click += new System.EventHandler(this.OnSignInClicked);
            // 
            // sign_in_player_name_text_box
            // 
            this.sign_in_player_name_text_box.Location = new System.Drawing.Point(102, 107);
            this.sign_in_player_name_text_box.Name = "sign_in_player_name_text_box";
            this.sign_in_player_name_text_box.Size = new System.Drawing.Size(157, 20);
            this.sign_in_player_name_text_box.TabIndex = 0;
            // 
            // SignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 270);
            this.Controls.Add(this.sign_in_root);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(384, 309);
            this.MinimumSize = new System.Drawing.Size(384, 309);
            this.Name = "SignInForm";
            this.Text = "SignInForm";
            this.sign_in_root.ResumeLayout(false);
            this.sign_in_root.PerformLayout();
            this.sign_in_error_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel sign_in_root;
        private System.Windows.Forms.Panel sign_in_error_panel;
        public System.Windows.Forms.Label sign_in_error_label;
        public System.Windows.Forms.Label sign_in_game_header_label;
        public System.Windows.Forms.Label sign_in_player_name;
        public System.Windows.Forms.Button sign_in_connect_button;
        public System.Windows.Forms.TextBox sign_in_player_name_text_box;
    }
}