using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpaceShooterGame
{
    public partial class ShopForm : Form
    {
        public ShopForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuyHP_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.BuyExtraHP(50))
            {
                MessageBox.Show("ارتقا با موفقیت خریداری شد!", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateShopUI(); // بروزرسانی نوشته‌های صفحه
            }
            else
            {
                MessageBox.Show("سکه‌های شما کافی نیست!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {
            UpdateShopUI();
        }
        private void UpdateShopUI()
        {
            lblShopCoins.Text = "Coins: " + DatabaseManager.GetTotalCoins().ToString();
            int currentExtraHP = DatabaseManager.GetExtraHP();
            btnBuyHP.Text = $"خرید جان اضافه (قیمت: 50) - تعداد فعلی: {currentExtraHP}";
        }
    }
}
