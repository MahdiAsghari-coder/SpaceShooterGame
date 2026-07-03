namespace SpaceShooterGame
{
    partial class MainMenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnplay = new Button();
            lblHighScore = new Label();
            lblTotalCoins = new Label();
            btnShop = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // btnplay
            // 
            btnplay.Location = new Point(199, 46);
            btnplay.Name = "btnplay";
            btnplay.Size = new Size(252, 98);
            btnplay.TabIndex = 1;
            btnplay.Text = "شروع بازی ";
            btnplay.UseVisualStyleBackColor = true;
            btnplay.Click += btnPlay_Click;
            // 
            // lblHighScore
            // 
            lblHighScore.AutoSize = true;
            lblHighScore.Location = new Point(533, 24);
            lblHighScore.Name = "lblHighScore";
            lblHighScore.Size = new Size(97, 20);
            lblHighScore.TabIndex = 2;
            lblHighScore.Text = "High Score: 0";
            // 
            // lblTotalCoins
            // 
            lblTotalCoins.AutoSize = true;
            lblTotalCoins.Location = new Point(533, 58);
            lblTotalCoins.Name = "lblTotalCoins";
            lblTotalCoins.Size = new Size(60, 20);
            lblTotalCoins.TabIndex = 3;
            lblTotalCoins.Text = "Coins: 0";
            // 
            // btnShop
            // 
            btnShop.Location = new Point(199, 168);
            btnShop.Name = "btnShop";
            btnShop.Size = new Size(252, 97);
            btnShop.TabIndex = 4;
            btnShop.Text = "فروشگاه";
            btnShop.UseVisualStyleBackColor = true;
            btnShop.Click += button1_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(21, 20);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(107, 58);
            btnExit.TabIndex = 5;
            btnExit.Text = "خروج";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 450);
            Controls.Add(btnExit);
            Controls.Add(btnShop);
            Controls.Add(lblTotalCoins);
            Controls.Add(lblHighScore);
            Controls.Add(btnplay);
            Name = "MainMenuForm";
            Text = "Space Shooter - Main Menu";
            Load += MainMenuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnplay;
        private Label lblHighScore;
        private Label lblTotalCoins;
        private Button btnShop;
        private Button btnExit;
    }
}
