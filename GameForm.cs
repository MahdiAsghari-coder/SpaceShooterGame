using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpaceShooterGame
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();//اینجوری فرم دوباره رسم میشه
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
