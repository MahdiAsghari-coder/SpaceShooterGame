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
        Player player = new Player(200, 400);
        public GameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//پرش صفحه نداریم دیگه با این خط
            this.KeyPreview = true;
        }
        // این متد برای نقاشی روی فرم است
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            player.Draw(e.Graphics);
        }

        // این متد برای حرکت با کیبورد است
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Left) player.MoveLeft();
            if (e.KeyCode == Keys.Right) player.MoveRight(this.ClientSize.Width);

            this.Invalidate(); // درخواست برای رسم مجدد
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
