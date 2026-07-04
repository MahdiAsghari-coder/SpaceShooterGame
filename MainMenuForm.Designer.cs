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
            Title = new Label();
            SuspendLayout();
            // 
            // btnplay
            // 
            btnplay.BackColor = Color.Green;
            btnplay.Font = new Font("Ink Free", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnplay.ForeColor = Color.Black;
            btnplay.Location = new Point(199, 79);
            btnplay.Name = "btnplay";
            btnplay.Size = new Size(252, 98);
            btnplay.TabIndex = 1;
            btnplay.Text = "Play";
            btnplay.UseVisualStyleBackColor = false;
            btnplay.Click += btnPlay_Click;
            // 
            // lblHighScore
            // 
            lblHighScore.AutoSize = true;
            lblHighScore.BackColor = Color.Green;
            lblHighScore.Location = new Point(533, 9);
            lblHighScore.Name = "lblHighScore";
            lblHighScore.Size = new Size(97, 20);
            lblHighScore.TabIndex = 2;
            lblHighScore.Text = "High Score: 0";
            // 
            // lblTotalCoins
            // 
            lblTotalCoins.AutoSize = true;
            lblTotalCoins.BackColor = Color.Green;
            lblTotalCoins.Location = new Point(533, 47);
            lblTotalCoins.Name = "lblTotalCoins";
            lblTotalCoins.Size = new Size(60, 20);
            lblTotalCoins.TabIndex = 3;
            lblTotalCoins.Text = "Coins: 0";
            // 
            // btnShop
            // 
            btnShop.BackColor = Color.Green;
            btnShop.Font = new Font("Ink Free", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnShop.ForeColor = Color.Black;
            btnShop.Location = new Point(199, 197);
            btnShop.Name = "btnShop";
            btnShop.Size = new Size(252, 97);
            btnShop.TabIndex = 4;
            btnShop.Text = "Shop";
            btnShop.UseVisualStyleBackColor = false;
            btnShop.Click += button1_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Green;
            btnExit.Location = new Point(12, 9);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(107, 58);
            btnExit.TabIndex = 5;
            btnExit.Text = "Quit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // Title
            // 
            Title.BackColor = Color.Green;
            Title.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Title.Location = new Point(153, 9);
            Title.Name = "Title";
            Title.Size = new Size(359, 58);
            Title.TabIndex = 6;
            Title.Text = "SpaceShooterGame";
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(659, 450);
            Controls.Add(Title);
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
        private Label Title;
    }
}
