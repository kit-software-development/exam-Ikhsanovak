namespace ClientApp.form
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.name_label = new System.Windows.Forms.Label();
            this.panel_for_text = new System.Windows.Forms.Panel();
            this.rules_label = new System.Windows.Forms.Label();
            this.common_info_label = new System.Windows.Forms.Label();
            this.img_panel = new System.Windows.Forms.Panel();
            this.panel_for_text.SuspendLayout();
            this.SuspendLayout();
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.BackColor = System.Drawing.Color.Transparent;
            this.name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name_label.Location = new System.Drawing.Point(57, 20);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(140, 25);
            this.name_label.TabIndex = 1;
            this.name_label.Text = "Игра \"Pong\"";
            // 
            // panel_for_text
            // 
            this.panel_for_text.BackColor = System.Drawing.Color.Transparent;
            this.panel_for_text.Controls.Add(this.rules_label);
            this.panel_for_text.Controls.Add(this.common_info_label);
            this.panel_for_text.Location = new System.Drawing.Point(12, 66);
            this.panel_for_text.Name = "panel_for_text";
            this.panel_for_text.Size = new System.Drawing.Size(258, 269);
            this.panel_for_text.TabIndex = 2;
            // 
            // rules_label
            // 
            this.rules_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rules_label.Location = new System.Drawing.Point(3, 72);
            this.rules_label.Name = "rules_label";
            this.rules_label.Size = new System.Drawing.Size(243, 179);
            this.rules_label.TabIndex = 1;
            this.rules_label.Text = resources.GetString("rules_label.Text");
            // 
            // common_info_label
            // 
            this.common_info_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.common_info_label.Location = new System.Drawing.Point(3, 9);
            this.common_info_label.Name = "common_info_label";
            this.common_info_label.Size = new System.Drawing.Size(252, 63);
            this.common_info_label.TabIndex = 0;
            this.common_info_label.Text = "- теннисная спортивная игра с использованием простой двумерной графики.";
            // 
            // img_panel
            // 
            this.img_panel.BackgroundImage = global::ClientApp.Properties.Resources.About;
            this.img_panel.Location = new System.Drawing.Point(284, 12);
            this.img_panel.Name = "img_panel";
            this.img_panel.Size = new System.Drawing.Size(237, 379);
            this.img_panel.TabIndex = 0;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BackgroundImage = global::ClientApp.Properties.Resources.back;
            this.ClientSize = new System.Drawing.Size(536, 403);
            this.Controls.Add(this.panel_for_text);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.img_panel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(552, 442);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(552, 442);
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutForm";
            this.panel_for_text.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel img_panel;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Panel panel_for_text;
        private System.Windows.Forms.Label rules_label;
        private System.Windows.Forms.Label common_info_label;
    }
}