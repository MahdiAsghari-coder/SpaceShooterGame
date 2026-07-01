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

            // حذف گلوله‌هایی که از صفحه خارج شدند
            bullets.RemoveAll(b => b.Y < 0);

            // چک کردن برخورد
            CheckCollisions();

            this.Invalidate();//اینجوری فرم دوباره رسم میشه
        }

        private void CheckCollisions()
        {
            var bulletsToRemove = new List<GameObject>();
            var enemiesToRemove = new List<GameObject>();

            foreach (var b in bullets)
            {
                foreach (var e in enemies)
                {
                    // ساخت مستطیل برای گلوله و دشمن جهت چک کردن برخورد
                    Rectangle bulletRect = new Rectangle(b.X, b.Y, b.Width, b.Height);
                    Rectangle enemyRect = new Rectangle(e.X, e.Y, e.Width, e.Height);

                    // اگر با هم برخورد داشتند
                    if (bulletRect.IntersectsWith(enemyRect))
                    {
                        bulletsToRemove.Add(b);
                        enemiesToRemove.Add(e);
                    }
                }
            }

            foreach (var b in bulletsToRemove) bullets.Remove(b);
            foreach (var e in enemiesToRemove) enemies.Remove(e);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
