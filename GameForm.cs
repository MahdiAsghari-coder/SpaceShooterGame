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
        List<GameObject> enemyBullets = new List<GameObject>();
        private int score = 0;
        Random rnd = new Random();
        private bool isMovingLeft = false;
        private bool isMovingRight = false;
        private bool isShooting = false;
        private int shootCooldown = 0; // تایمر برای فاصله بین شلیک‌ها
        private const int FIRE_RATE_DELAY = 10;

        private int currentWave = 1;
        private int enemiesDefeatedInWave = 0;
        private int enemiesNeededForWave = 10;
        private bool isBossSpawned = false;


        Player player = new Player(200, 400);
        public GameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//پرش صفحه نداریم دیگه با این خط
            this.KeyPreview = true;

            // اضافه کردن چند دشمن برای تست
            enemies.Add(new StandardEnemy(50, 50));
            enemies.Add(new StandardEnemy(150, 50));
        }
        // این متد برای نقاشی روی فرم است
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            player.Draw(e.Graphics);

            foreach (var enemy in enemies)
            {
                enemy.Draw(e.Graphics);
            }
            foreach (var b in bullets)
            {
                b.Draw(e.Graphics);
            }
            foreach (var eb in enemyBullets)
            {
                eb.Draw(e.Graphics);
            }
            // نمایش امتیاز در گوشه صفحه
            e.Graphics.DrawString("Score: " + score, new Font("Arial", 16), Brushes.Black, new Point(10, 10));
            // نمایش شماره موج
            e.Graphics.DrawString("Wave: " + currentWave + " / 10", new Font("Arial", 16), Brushes.Red, new Point(10, 40));

        }

        // این متد برای حرکت با کیبورد است
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Left) isMovingLeft = true;
            if (e.KeyCode == Keys.Right) isMovingRight = true;
            if (e.KeyCode == Keys.Space) isShooting = true; // دستت روی اسپیس هست
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Left) isMovingLeft = false;
            if (e.KeyCode == Keys.Right) isMovingRight = false;
            if (e.KeyCode == Keys.Space) isShooting = false; // دستت رو از اسپیس برداشتی
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isMovingLeft) player.MoveLeft();
            if (isMovingRight) player.MoveRight(this.ClientSize.Width);

            if (shootCooldown > 0) shootCooldown--;

            if (isShooting && shootCooldown == 0)
            {
                bullets.Add(new Bullet(player.X + 20, player.Y));
                shootCooldown = FIRE_RATE_DELAY; // قفل کردن شلیک برای فریم‌های بعدی
            }

            int enemySpeed = 3; // سرعت اولیه

            // منطق افزایش سرعت بر اساس امتیاز
            if (score >= 100 && score < 200) enemySpeed = 5;
            else if (score >= 200) enemySpeed = 7;

            // استفاده از سرعت متغیر در حرکت دشمن‌ها
            foreach (var enemy in enemies)
            {
                ((Enemy)enemy).Y += enemySpeed;
            }

            foreach (var enemy in enemies)
            {
                ((Enemy)enemy).Move(player.X, player.Y);
                ((Enemy)enemy).Shoot(enemyBullets);
            }

            foreach (var eb in enemyBullets)
            {
                ((EnemyBullet)eb).Move();
            }


            foreach (var bullet in bullets)
            {
                ((Bullet)bullet).MoveUp();
            }

            // حذف گلوله‌هایی که از صفحه خارج شدند
            bullets.RemoveAll(b => b.Y < 0);

            // چک کردن برخورد
            CheckCollisions();




            if (enemiesDefeatedInWave >= enemiesNeededForWave && !isBossSpawned)
            {
                if (currentWave == 10)
                {
                    isBossSpawned = true;
                    enemies.Add(new HeavyTankEnemy(this.ClientSize.Width / 2 - 40, -80));
                }
                else
                {
                    timer1.Stop();
                    MessageBox.Show("Wave " + currentWave + " Cleared! Get ready for next wave.", "Wave Complete");

                    currentWave++;
                    enemiesDefeatedInWave = 0;

                    timer1.Start();
                }
            }

            if (currentWave < 10 && rnd.Next(0, 50) == 1)
            {
                int randomX = rnd.Next(0, this.ClientSize.Width - 40);
                Enemy newEnemy;

                if (currentWave >= 3 && rnd.Next(0, 3) == 0)
                    newEnemy = new ShooterEnemy(randomX, -50);
                else if (currentWave >= 2 && rnd.Next(0, 2) == 0)
                    newEnemy = new ScoutEnemy(randomX, -50);
                else
                    newEnemy = new StandardEnemy(randomX, -50);

                newEnemy.HP = newEnemy.HP + (2 * currentWave);

                enemies.Add(newEnemy);
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
                        Enemy hitEnemy = (Enemy)e;
                        hitEnemy.HP -= 2;
                        bulletsToRemove.Add(b);

                        if (hitEnemy.HP <= 0)
                        {
                            score += 10;
                            enemiesDefeatedInWave++;
                            enemiesToRemove.Add(e);

                            if (hitEnemy is HeavyTankEnemy)
                            {
                                timer1.Stop();
                                MessageBox.Show("تبریک! شما غول را کشتید و بازی تمام شد!", "پایان بازی");
                                this.Close();
                            }
                        }
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
