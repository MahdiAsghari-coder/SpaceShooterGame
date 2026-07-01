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

        List<GameObject> enemies = new List<GameObject>();
        List<GameObject> bullets = new List<GameObject>();

        Player player = new Player(200, 400);
        public GameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//پرش صفحه نداریم دیگه با این خط
            this.KeyPreview = true;

            // اضافه کردن چند دشمن برای تست
            enemies.Add(new Enemy(50, 50));
            enemies.Add(new Enemy(150, 50));
        }
        // این متد برای نقاشی روی فرم است
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            player.Draw(e.Graphics);

            // رسم تمام دشمن‌های داخل لیست
            foreach (var enemy in enemies)
            {
                enemy.Draw(e.Graphics);
            }
            foreach (var b in bullets)
            {
                b.Draw(e.Graphics);
            }
        }

        // این متد برای حرکت با کیبورد است
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Left) player.MoveLeft();
            if (e.KeyCode == Keys.Right) player.MoveRight(this.ClientSize.Width);

            if (e.KeyCode == Keys.Space) // با دکمه اسپیس شلیک کن
            {
                bullets.Add(new Bullet(player.X + 20, player.Y));
            }

            this.Invalidate(); // درخواست برای رسم مجدد
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // حرکت دادن همه دشمن‌ها
            foreach (var enemy in enemies)
            {
                ((Enemy)enemy).MoveDown();
            }

            foreach (var bullet in bullets)
            {
                ((Bullet)bullet).MoveUp();
            }

            this.Invalidate();//اینجوری فرم دوباره رسم میشه
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
