namespace SpaceShooterGame
{
    partial class ShopForm
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
            lblShopCoins = new Label();
            btnBuyHP = new Button();
            btnBack = new Button();
            btnBuyEagle = new Button();
            btnBuyGhost = new Button();
            btnBuyMars = new Button();
            btnBuyGalaxy = new Button();
            btnBuyPlasma = new Button();
            btnBuyGreen = new Button();
            lblMessage = new Label();
            SuspendLayout();
            // 
            // lblShopCoins
            // 
            lblShopCoins.AutoSize = true;
            lblShopCoins.BackColor = Color.Green;
            lblShopCoins.Location = new Point(603, 20);
            lblShopCoins.Name = "lblShopCoins";
            lblShopCoins.Size = new Size(60, 20);
            lblShopCoins.TabIndex = 0;
            lblShopCoins.Text = "Coins: 0";
            // 
            // btnBuyHP
            // 
            btnBuyHP.BackColor = Color.Green;
            btnBuyHP.Location = new Point(239, 70);
            btnBuyHP.Name = "btnBuyHP";
            btnBuyHP.Size = new Size(232, 58);
            btnBuyHP.TabIndex = 1;
            btnBuyHP.Text = "خرید جان اضافه (قیمت: ۵۰ سکه)";
            btnBuyHP.UseVisualStyleBackColor = false;
            btnBuyHP.Click += btnBuyHP_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Green;
            btnBack.Location = new Point(12, 20);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(200, 57);
            btnBack.TabIndex = 2;
            btnBack.Text = "بازگشت به منوی اصلی";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnBuyEagle
            // 
            btnBuyEagle.BackColor = Color.Green;
            btnBuyEagle.Location = new Point(239, 153);
            btnBuyEagle.Name = "btnBuyEagle";
            btnBuyEagle.Size = new Size(232, 61);
            btnBuyEagle.TabIndex = 3;
            btnBuyEagle.Text = "خرید سفینه عقاب قرمز (۱۰۰ سکه)";
            btnBuyEagle.UseVisualStyleBackColor = false;
            btnBuyEagle.Click += btnBuyEagle_Click;
            // 
            // btnBuyGhost
            // 
            btnBuyGhost.BackColor = Color.Green;
            btnBuyGhost.Location = new Point(239, 239);
            btnBuyGhost.Name = "btnBuyGhost";
            btnBuyGhost.Size = new Size(232, 57);
            btnBuyGhost.TabIndex = 4;
            btnBuyGhost.Text = "خرید سفینه روح بنفش (۱۵۰ سکه)";
            btnBuyGhost.UseVisualStyleBackColor = false;
            btnBuyGhost.Click += btnBuyGhost_Click;
            // 
            // btnBuyMars
            // 
            btnBuyMars.BackColor = Color.Green;
            btnBuyMars.Location = new Point(239, 313);
            btnBuyMars.Name = "btnBuyMars";
            btnBuyMars.Size = new Size(232, 60);
            btnBuyMars.TabIndex = 5;
            btnBuyMars.Text = "خرید پس‌زمینه مریخ (70 سکه)";
            btnBuyMars.UseVisualStyleBackColor = false;
            btnBuyMars.Click += btnBuyMars_Click;
            // 
            // btnBuyGalaxy
            // 
            btnBuyGalaxy.BackColor = Color.Green;
            btnBuyGalaxy.Location = new Point(495, 83);
            btnBuyGalaxy.Name = "btnBuyGalaxy";
            btnBuyGalaxy.Size = new Size(164, 58);
            btnBuyGalaxy.TabIndex = 6;
            btnBuyGalaxy.Text = "خرید پس‌زمینه کهکشان (100 سکه)";
            btnBuyGalaxy.UseVisualStyleBackColor = false;
            btnBuyGalaxy.Click += btnBuyGalaxy_Click;
            // 
            // btnBuyPlasma
            // 
            btnBuyPlasma.BackColor = Color.Green;
            btnBuyPlasma.Location = new Point(495, 179);
            btnBuyPlasma.Name = "btnBuyPlasma";
            btnBuyPlasma.Size = new Size(164, 50);
            btnBuyPlasma.TabIndex = 7;
            btnBuyPlasma.Text = "خرید تیر پلاسما (۸۰ سکه)";
            btnBuyPlasma.UseVisualStyleBackColor = false;
            btnBuyPlasma.Click += btnBuyPlasma_Click;
            // 
            // btnBuyGreen
            // 
            btnBuyGreen.BackColor = Color.Green;
            btnBuyGreen.Location = new Point(495, 268);
            btnBuyGreen.Name = "btnBuyGreen";
            btnBuyGreen.Size = new Size(164, 48);
            btnBuyGreen.TabIndex = 8;
            btnBuyGreen.Text = "خرید تیر سبز (۶۰ سکه)";
            btnBuyGreen.UseVisualStyleBackColor = false;
            btnBuyGreen.Click += btnBuyGreen_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.ForeColor = Color.Red;
            lblMessage.Location = new Point(276, 20);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 20);
            lblMessage.TabIndex = 9;
            // 
            // ShopForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(699, 450);
            Controls.Add(lblMessage);
            Controls.Add(btnBuyGreen);
            Controls.Add(btnBuyPlasma);
            Controls.Add(btnBuyGalaxy);
            Controls.Add(btnBuyMars);
            Controls.Add(btnBuyGhost);
            Controls.Add(btnBuyEagle);
            Controls.Add(btnBack);
            Controls.Add(btnBuyHP);
            Controls.Add(lblShopCoins);
            Name = "ShopForm";
            Text = "ShopForm";
            Load += ShopForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblShopCoins;
        private Button btnBuyHP;
        private Button btnBack;
        private Button btnBuyEagle;
        private Button btnBuyGhost;
        private Button btnBuyMars;
        private Button btnBuyGalaxy;
        private Button btnBuyPlasma;
        private Button btnBuyGreen;
        private Label lblMessage;
    }
}