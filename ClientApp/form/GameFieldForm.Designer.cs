namespace ClientApp.form
{
    partial class GameFieldForm
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
            this.game_root = new System.Windows.Forms.Panel();
            this.game_ball = new System.Windows.Forms.Panel();
            this.game_right_board = new System.Windows.Forms.Panel();
            this.game_left_board = new System.Windows.Forms.Panel();
            this.game_right_wins_label = new System.Windows.Forms.Label();
            this.game_left_wins_label = new System.Windows.Forms.Label();
            this.game_right_score_label = new System.Windows.Forms.Label();
            this.game_left_score_label = new System.Windows.Forms.Label();
            this.game_right_name_label = new System.Windows.Forms.Label();
            this.game_left_name_label = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.game_root.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // game_root
            // 
            this.game_root.BackColor = System.Drawing.Color.MintCream;
            this.game_root.Controls.Add(this.game_ball);
            this.game_root.Controls.Add(this.game_right_board);
            this.game_root.Controls.Add(this.game_left_board);
            this.game_root.Controls.Add(this.game_right_wins_label);
            this.game_root.Controls.Add(this.game_left_wins_label);
            this.game_root.Controls.Add(this.game_right_score_label);
            this.game_root.Controls.Add(this.game_left_score_label);
            this.game_root.Controls.Add(this.game_right_name_label);
            this.game_root.Controls.Add(this.game_left_name_label);
            this.game_root.Location = new System.Drawing.Point(0, 27);
            this.game_root.Name = "game_root";
            this.game_root.Size = new System.Drawing.Size(512, 256);
            this.game_root.TabIndex = 0;
            // 
            // game_ball
            // 
            this.game_ball.BackColor = System.Drawing.Color.Black;
            this.game_ball.Location = new System.Drawing.Point(240, 112);
            this.game_ball.Name = "game_ball";
            this.game_ball.Size = new System.Drawing.Size(32, 32);
            this.game_ball.TabIndex = 6;
            // 
            // game_right_board
            // 
            this.game_right_board.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.game_right_board.Location = new System.Drawing.Point(448, 96);
            this.game_right_board.Name = "game_right_board";
            this.game_right_board.Size = new System.Drawing.Size(32, 64);
            this.game_right_board.TabIndex = 5;
            // 
            // game_left_board
            // 
            this.game_left_board.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.game_left_board.Location = new System.Drawing.Point(32, 96);
            this.game_left_board.Name = "game_left_board";
            this.game_left_board.Size = new System.Drawing.Size(32, 64);
            this.game_left_board.TabIndex = 4;
            // 
            // game_right_wins_label
            // 
            this.game_right_wins_label.BackColor = System.Drawing.Color.Transparent;
            this.game_right_wins_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.game_right_wins_label.Location = new System.Drawing.Point(368, 21);
            this.game_right_wins_label.Name = "game_right_wins_label";
            this.game_right_wins_label.Size = new System.Drawing.Size(144, 32);
            this.game_right_wins_label.TabIndex = 8;
            this.game_right_wins_label.Text = "wins: 0";
            this.game_right_wins_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // game_left_wins_label
            // 
            this.game_left_wins_label.BackColor = System.Drawing.Color.Transparent;
            this.game_left_wins_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.game_left_wins_label.Location = new System.Drawing.Point(-3, 21);
            this.game_left_wins_label.Name = "game_left_wins_label";
            this.game_left_wins_label.Size = new System.Drawing.Size(144, 32);
            this.game_left_wins_label.TabIndex = 7;
            this.game_left_wins_label.Text = "wins: 0";
            this.game_left_wins_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // game_right_score_label
            // 
            this.game_right_score_label.BackColor = System.Drawing.Color.Transparent;
            this.game_right_score_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.game_right_score_label.Location = new System.Drawing.Point(368, 224);
            this.game_right_score_label.Name = "game_right_score_label";
            this.game_right_score_label.Size = new System.Drawing.Size(144, 32);
            this.game_right_score_label.TabIndex = 3;
            this.game_right_score_label.Text = "0/5";
            this.game_right_score_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // game_left_score_label
            // 
            this.game_left_score_label.BackColor = System.Drawing.Color.Transparent;
            this.game_left_score_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.game_left_score_label.Location = new System.Drawing.Point(-3, 224);
            this.game_left_score_label.Name = "game_left_score_label";
            this.game_left_score_label.Size = new System.Drawing.Size(144, 32);
            this.game_left_score_label.TabIndex = 2;
            this.game_left_score_label.Text = "0/5";
            this.game_left_score_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // game_right_name_label
            // 
            this.game_right_name_label.BackColor = System.Drawing.Color.Transparent;
            this.game_right_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.game_right_name_label.Location = new System.Drawing.Point(368, 0);
            this.game_right_name_label.Name = "game_right_name_label";
            this.game_right_name_label.Size = new System.Drawing.Size(144, 21);
            this.game_right_name_label.TabIndex = 1;
            this.game_right_name_label.Text = "right_player";
            this.game_right_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // game_left_name_label
            // 
            this.game_left_name_label.BackColor = System.Drawing.Color.Transparent;
            this.game_left_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.game_left_name_label.Location = new System.Drawing.Point(-3, 0);
            this.game_left_name_label.Name = "game_left_name_label";
            this.game_left_name_label.Size = new System.Drawing.Size(144, 21);
            this.game_left_name_label.TabIndex = 0;
            this.game_left_name_label.Text = "left_player";
            this.game_left_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip
            // 
            this.menuStrip.BackgroundImage = global::ClientApp.Properties.Resources.back;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(512, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.OnSignInClick);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.OnAboutClick);
            // 
            // GameFieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(512, 283);
            this.Controls.Add(this.game_root);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(528, 322);
            this.MinimumSize = new System.Drawing.Size(528, 322);
            this.Name = "GameFieldForm";
            this.Text = "PongApplication";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPressed);
            this.game_root.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        public System.Windows.Forms.Panel game_root;
        public System.Windows.Forms.Label game_right_score_label;
        public System.Windows.Forms.Label game_left_score_label;
        public System.Windows.Forms.Label game_right_name_label;
        public System.Windows.Forms.Label game_left_name_label;
        public System.Windows.Forms.Panel game_ball;
        public System.Windows.Forms.Panel game_right_board;
        public System.Windows.Forms.Panel game_left_board;
        public System.Windows.Forms.Label game_right_wins_label;
        public System.Windows.Forms.Label game_left_wins_label;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
    }
}

