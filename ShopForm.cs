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
                lblMessage.ForeColor = System.Drawing.Color.Green; // تغییر رنگ به سبز برای موفقیت
                lblMessage.Text = "ارتقای جان با موفقیت خریداری و اعمال شد!";
                UpdateShopUI();
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red; // تغییر رنگ به قرمز برای خطا
                lblMessage.Text = "سکه کافی موجود نیست!";
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

            lblMessage.Text = "";

        }

        private void btnBuyEagle_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.BuyAndEquipSkin("ShipSkin", 1, 100))
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "سفینه عقاب خریداری و مجهز شد!";
                UpdateShopUI();
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "سکه کافی موجود نیست!";
            }
        }

        private void btnBuyGhost_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.BuyAndEquipSkin("ShipSkin", 2, 150))
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "سفینه روح خریداری و مجهز شد!";
                UpdateShopUI();
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "سکه کافی موجود نیست!";
            }
        }

        private void btnBuyMars_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.BuyAndEquipSkin("BgSkin", 1, 75))
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "پس‌زمینه مریخ خریداری و اعمال شد!";
                UpdateShopUI();
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "سکه کافی موجود نیست!";
            }
        }

        private void btnBuyGalaxy_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.BuyAndEquipSkin("BgSkin", 2, 75))
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "پس‌زمینه کهکشان خریداری و اعمال شد!";
                UpdateShopUI();
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "سکه کافی موجود نیست!";
            }
        }

        private void btnBuyPlasma_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.BuyAndEquipSkin("BulletSkin", 1, 80))
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "تیر بنفش خریداری و مجهز شد!";
                UpdateShopUI();
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "سکه کافی موجود نیست!";
            }
        }

        private void btnBuyGreen_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.BuyAndEquipSkin("BulletSkin", 2, 60))
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "تیر سبز خریداری و مجهز شد!";
                UpdateShopUI();
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "سکه کافی موجود نیست!";
            }
        }
    }
}
