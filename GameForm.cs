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
        private bool isWaveTransition = false;
        private int transitionTimer = 0;

        private bool isGameOver = false;
        private int invincibilityTimer = 0;
        private const int InvincibilityDuration = 50;

        List<GameObject> powerUps = new List<GameObject>();
        private int powerUpCounter = 0;//که مثلا هر 4 تا دشمن که مرد پاور بندازه

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

            if (isWaveTransition)
            {
                string msg = "Wave " + currentWave + " Completed!\nGet Ready...";
                Font bigFont = new Font("Arial", 24, FontStyle.Bold);
                SizeF textSize = e.Graphics.MeasureString(msg, bigFont);

                e.Graphics.DrawString(msg, bigFont, Brushes.Yellow,
                    (this.ClientSize.Width - textSize.Width) / 2,
                    (this.ClientSize.Height - textSize.Height) / 2);
            }

            e.Graphics.DrawString("Lives: " + player.HP, new Font("Arial", 16, FontStyle.Bold), Brushes.Green, new Point(10, 70));

            foreach (var enemy in enemies)
            {
                Enemy en = (Enemy)enemy;

                if (en.MaxHP > 0 && en.HP > 0)
                {
                    float hpPercentage = (float)en.HP / en.MaxHP;

                    if (hpPercentage > 1) hpPercentage = 1;

                    int barWidth = (int)(en.Width * hpPercentage);

                    e.Graphics.FillRectangle(Brushes.Red, en.X, en.Y - 8, en.Width, 4);

                    e.Graphics.FillRectangle(Brushes.LimeGreen, en.X, en.Y - 8, barWidth, 4);
                }
            }

            if (isGameOver)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.Black)), 0, 0, this.ClientSize.Width, this.ClientSize.Height);

                string gameOverText = "GAME OVER";
                string scoreText = "Your Score: " + score;
                string restartText = "Press ESC to Return to Menu";

                Font fontTitle = new Font("Arial", 36, FontStyle.Bold);
                Font fontSub = new Font("Arial", 18, FontStyle.Regular);

                SizeF sizeTitle = e.Graphics.MeasureString(gameOverText, fontTitle);
                SizeF sizeScore = e.Graphics.MeasureString(scoreText, fontSub);
                SizeF sizeRestart = e.Graphics.MeasureString(restartText, fontSub);

                int centerX = this.ClientSize.Width / 2;
                int centerY = this.ClientSize.Height / 2;

                e.Graphics.DrawString(gameOverText, fontTitle, Brushes.Red, centerX - (sizeTitle.Width / 2), centerY - 60);
                e.Graphics.DrawString(scoreText, fontSub, Brushes.White, centerX - (sizeScore.Width / 2), centerY + 10);
                e.Graphics.DrawString(restartText, fontSub, Brushes.Yellow, centerX - (sizeRestart.Width / 2), centerY + 50);
            }

            foreach (var pw in powerUps)
            {
                pw.Draw(e.Graphics);
            }

            if (player.ShieldTimer > 0)
            {
                using (Pen shieldPen = new Pen(Color.Cyan, 2))
                {
                    e.Graphics.DrawEllipse(shieldPen, player.X - 8, player.Y - 8, player.Width + 16, player.Height + 16);
                }
            }

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Left) isMovingLeft = true;
            if (e.KeyCode == Keys.Right) isMovingRight = true;
            if (e.KeyCode == Keys.Space) isShooting = true;
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
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
            if (isGameOver) return;

            if (player.ShieldTimer > 0) player.ShieldTimer--;
            if (player.TripleShotTimer > 0) player.TripleShotTimer--;

            foreach (var pw in powerUps)
            {
                ((PowerUp)pw).Move();
            }
            if (isWaveTransition)
            {
                transitionTimer++;
                if (transitionTimer > 100)
                {
                    isWaveTransition = false;
                    transitionTimer = 0;
                    currentWave++;
                    enemiesDefeatedInWave = 0;
                    bullets.Clear();
                }
                this.Invalidate();
                return;
            }

            if (isMovingLeft) player.MoveLeft();
            if (isMovingRight) player.MoveRight(this.ClientSize.Width);

            if (shootCooldown > 0) shootCooldown--;

            if (isShooting && shootCooldown == 0)
            {
                if (player.TripleShotTimer > 0)
                {
                    bullets.Add(new Bullet(player.X - 10, player.Y));
                    bullets.Add(new Bullet(player.X + 20, player.Y));
                    bullets.Add(new Bullet(player.X + 50, player.Y));
                }
                else
                {
                    bullets.Add(new Bullet(player.X + 20, player.Y));
                }
                shootCooldown = FIRE_RATE_DELAY;
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
                    isWaveTransition = true;
                }
            }

            if (currentWave < 10 && rnd.Next(0, 50) == 1)
            {
                int randomX = rnd.Next(0, this.ClientSize.Width - 40);
                Enemy newEnemy;

                if (currentWave >= 3 && rnd.Next(0, 3) == 0) newEnemy = new ShooterEnemy(randomX, -50);
                else if (currentWave >= 2 && rnd.Next(0, 2) == 0) newEnemy = new ScoutEnemy(randomX, -50);
                else newEnemy = new StandardEnemy(randomX, -50);

                newEnemy.HP = newEnemy.HP + (2 * currentWave);
                newEnemy.MaxHP = newEnemy.HP;
                newEnemy.Speed = (int)(newEnemy.Speed * (1 + 0.1 * currentWave));

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
                        hitEnemy.HP -= 1;
                        bulletsToRemove.Add(b);

                        if (hitEnemy.HP <= 0)
                        {
                            score += hitEnemy.EnemyScore;
                            enemiesDefeatedInWave++;
                            enemiesToRemove.Add(e);

                            powerUpCounter++;
                            if (powerUpCounter >= 4)
                            {
                                powerUpCounter = 0;

                                int type = rnd.Next(0, 3);
                                if (type == 0) powerUps.Add(new HealthPowerUp(hitEnemy.X, hitEnemy.Y));
                                else if (type == 1) powerUps.Add(new ShieldPowerUp(hitEnemy.X, hitEnemy.Y));
                                else if (type == 2) powerUps.Add(new TripleShotPowerUp(hitEnemy.X, hitEnemy.Y));
                            }

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



            Rectangle playerRect = new Rectangle(player.X, player.Y, player.Width, player.Height);
            var enemyBulletsToRemove = new List<GameObject>();

            if (invincibilityTimer > 0)
            {
                invincibilityTimer--;
            }

            foreach (var eb in enemyBullets)
            {
                Rectangle ebRect = new Rectangle(eb.X, eb.Y, eb.Width, eb.Height);
                if (ebRect.IntersectsWith(playerRect))
                {
                    enemyBulletsToRemove.Add(eb);

                    if (player.ShieldTimer == 0 && invincibilityTimer == 0 && !isGameOver)
                    {
                        player.HP -= 1;
                        invincibilityTimer = InvincibilityDuration;
                    }
                }
            }
            foreach (var eb in enemyBulletsToRemove) enemyBullets.Remove(eb);

            foreach (var e in enemies)
            {
                Rectangle enemyRect = new Rectangle(e.X, e.Y, e.Width, e.Height);
                if (enemyRect.IntersectsWith(playerRect))
                {
                    ((Enemy)e).HP = 0;

                    if (player.ShieldTimer == 0 && invincibilityTimer == 0 && !isGameOver)
                    {
                        player.HP -= 1;
                        invincibilityTimer = InvincibilityDuration;
                    }
                }
            }

            if (player.HP <= 0 && !isGameOver)
            {
                isGameOver = true;
                timer1.Stop();
                this.Invalidate(); 
            }

            var powerUpsToRemove = new List<GameObject>();
            Rectangle pRect = new Rectangle(player.X, player.Y, player.Width, player.Height);

            foreach (var pw in powerUps)
            {
                Rectangle pwRect = new Rectangle(pw.X, pw.Y, pw.Width, pw.Height);

                if (pwRect.IntersectsWith(pRect))
                {
                    ((PowerUp)pw).ApplyEffect(player);
                    powerUpsToRemove.Add(pw);
                }
                else if (pw.Y > this.ClientSize.Height)
                {
                    powerUpsToRemove.Add(pw);
                }
            }

            foreach (var pw in powerUpsToRemove) powerUps.Remove(pw);

        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
