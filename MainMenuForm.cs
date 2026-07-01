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
            GameForm gameForm = new GameForm();
            this.Hide();           // منو مخفی شود
            gameForm.ShowDialog();  // بازی اجرا شود
            this.Show();           // وقتی بازی بسته شد، منو برگردد
        }
    }
}