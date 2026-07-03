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
            SuspendLayout();
            // 
            // lblShopCoins
            // 
            lblShopCoins.AutoSize = true;
            lblShopCoins.Location = new Point(603, 20);
            lblShopCoins.Name = "lblShopCoins";
            lblShopCoins.Size = new Size(60, 20);
            lblShopCoins.TabIndex = 0;
            lblShopCoins.Text = "Coins: 0";
            // 
            // btnBuyHP
            // 
            btnBuyHP.Location = new Point(239, 72);
            btnBuyHP.Name = "btnBuyHP";
            btnBuyHP.Size = new Size(197, 58);
            btnBuyHP.TabIndex = 1;
            btnBuyHP.Text = "خرید جان اضافه (قیمت: ۵۰ سکه)";
            btnBuyHP.UseVisualStyleBackColor = true;
            btnBuyHP.Click += btnBuyHP_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 20);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(200, 57);
            btnBack.TabIndex = 2;
            btnBack.Text = "بازگشت به منوی اصلی";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // ShopForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 450);
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
    }
}