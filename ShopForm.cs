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
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "ارتقای جان با موفقیت خریداری و اعمال شد!";
                UpdateShopUI();
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "سکه کافی موجود نیست!";
            }
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {
            UpdateShopUI();
        }
        private void UpdateShopUI()
        {
            lblMessage.Text = "";

            lblShopCoins.Text = "Coins: " + DatabaseManager.GetTotalCoins().ToString();
            int currentExtraHP = DatabaseManager.GetExtraHP();
            btnBuyHP.Text = $"خرید جان اضافه (قیمت: 50) - تعداد فعلی: {currentExtraHP}";

            // تغییر متن دکمه‌های سفینه
            btnBuyEagle.Text = DatabaseManager.IsOwned("OwnsEagle") ? "انتخاب سفینه عقاب (دارید)" : "خرید سفینه عقاب قرمز (100 سکه)";
            btnBuyGhost.Text = DatabaseManager.IsOwned("OwnsGhost") ? "انتخاب سفینه روح (دارید)" : "خرید سفینه روح بنفش (150 سکه)";

            // تغییر متن دکمه پس‌زمینه
            btnBuyGalaxy.Text = DatabaseManager.IsOwned("OwnsGalaxy") ? "انتخاب پس‌زمینه کهکشان (دارید)" : "خرید پس‌زمینه کهکشان (100 سکه)";

            btnBuyMars.Text = DatabaseManager.IsOwned("OwnsMars") ? "انتخاب پس‌زمینه مریخ (دارید)" : "خرید پس‌زمینه مریخ (70 سکه)";

            // تغییر متن دکمه‌های تیر
            btnBuyPlasma.Text = DatabaseManager.IsOwned("OwnsPlasma") ? "انتخاب تیر پلاسما (دارید)" : "خرید تیر پلاسما (80 سکه)";
            btnBuyGreen.Text = DatabaseManager.IsOwned("OwnsGreen") ? "انتخاب تیر سبز (دارید)" : "خرید تیر سبز (60 سکه)";

        }

        private void btnBuyEagle_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.IsOwned("OwnsEagle"))
            {
                DatabaseManager.EquipSkin("ShipSkin", 1);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "سفینه عقاب به عنوان سفینه اصلی انتخاب شد!";
            }
            else
            {
                if (DatabaseManager.BuyAndOwnSkin("ShipSkin", 1, 100, "OwnsEagle"))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "سفینه عقاب خریداری شد!";
                    UpdateShopUI();
                }
                else { lblMessage.ForeColor = System.Drawing.Color.Red; lblMessage.Text = "سکه کافی موجود نیست!"; }
            }
        }

        private void btnBuyGhost_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.IsOwned("OwnsGhost"))
            {
                DatabaseManager.EquipSkin("ShipSkin", 2);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "سفینه روح به عنوان سفینه اصلی انتخاب شد!";
            }
            else
            {
                if (DatabaseManager.BuyAndOwnSkin("ShipSkin", 2, 150, "OwnsGhost"))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "سفینه روح خریداری شد!";
                    UpdateShopUI();
                }
                else { lblMessage.ForeColor = System.Drawing.Color.Red; lblMessage.Text = "سکه کافی موجود نیست!"; }
            }
        }

        private void btnBuyMars_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.IsOwned("OwnsMars"))
            {
                DatabaseManager.EquipSkin("BgSkin", 1); // عدد 1 یعنی مریخ
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "پس‌زمینه مریخ انتخاب شد!";
            }
            else
            {
                if (DatabaseManager.BuyAndOwnSkin("BgSkin", 1, 70, "OwnsMars"))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "پس‌زمینه مریخ خریداری شد!";
                    UpdateShopUI();
                }
                else { lblMessage.ForeColor = System.Drawing.Color.Red; lblMessage.Text = "سکه کافی موجود نیست!"; }
            }
        }

        private void btnBuyGalaxy_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.IsOwned("OwnsGalaxy"))
            {
                DatabaseManager.EquipSkin("BgSkin", 2);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "پس‌زمینه کهکشان انتخاب شد!";
            }
            else
            {
                if (DatabaseManager.BuyAndOwnSkin("BgSkin", 2, 100, "OwnsGalaxy"))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "پس‌زمینه کهکشان خریداری شد!";
                    UpdateShopUI();
                }
                else { lblMessage.ForeColor = System.Drawing.Color.Red; lblMessage.Text = "سکه کافی موجود نیست!"; }
            }
        }

        private void btnBuyPlasma_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.IsOwned("OwnsPlasma"))
            {
                DatabaseManager.EquipSkin("BulletSkin", 1);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "تیر پلاسما انتخاب شد!";
            }
            else
            {
                if (DatabaseManager.BuyAndOwnSkin("BulletSkin", 1, 80, "OwnsPlasma"))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "تیر پلاسما خریداری شد!";
                    UpdateShopUI();
                }
                else { lblMessage.ForeColor = System.Drawing.Color.Red; lblMessage.Text = "سکه کافی موجود نیست!"; }
            }
        }

        private void btnBuyGreen_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.IsOwned("OwnsGreen"))
            {
                DatabaseManager.EquipSkin("BulletSkin", 2);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "تیر سبز انتخاب شد!";
            }
            else
            {
                if (DatabaseManager.BuyAndOwnSkin("BulletSkin", 2, 60, "OwnsGreen"))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "تیر سبز خریداری شد!";
                    UpdateShopUI();
                }
                else { lblMessage.ForeColor = System.Drawing.Color.Red; lblMessage.Text = "سکه کافی موجود نیست!"; }
            }
        }
    }
}
