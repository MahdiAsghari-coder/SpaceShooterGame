using System;
using System.Windows.Forms;

namespace SpaceShooterGame
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm game = new GameForm();
            game.ShowDialog();
            this.Show();
            UpdateStats();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShopForm shop = new ShopForm();
            shop.ShowDialog();
            this.Show();
            UpdateStats();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            UpdateStats();
        }
        private void UpdateStats()
        {
            lblHighScore.Text = "High Score: " + DatabaseManager.GetHighScore().ToString();
            lblTotalCoins.Text = "Total Coins: " + DatabaseManager.GetTotalCoins().ToString();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }
    }
}