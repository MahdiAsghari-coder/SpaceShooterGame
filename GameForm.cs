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
        private int score = 0;
        Random rnd = new Random();

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
            // نمایش امتیاز در گوشه صفحه
            e.Graphics.DrawString("Score: " + score, new Font("Arial", 16), Brushes.Black, new Point(10, 10));

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
            int enemySpeed = 3; // سرعت اولیه

            // منطق افزایش سرعت بر اساس امتیاز
            if (score >= 100 && score < 200) enemySpeed = 5;
            else if (score >= 200) enemySpeed = 7;

            // استفاده از سرعت متغیر در حرکت دشمن‌ها
            foreach (var enemy in enemies)
            {
                ((Enemy)enemy).Y += enemySpeed;
            }

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

            // تولید دشمن جدید هر ۵۰ تیک یک‌بار
            if (rnd.Next(0, 50) == 1)
            {
                enemies.Add(new Enemy(rnd.Next(0, this.ClientSize.Width - 40), -50));
            }


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
                        score += 1;
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
