using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

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
        bool isMovingUp = false;
        bool isMovingDown = false;
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
        
        
        List<GameObject> coinsList = new List<GameObject>();
        private int sessionCoins = 0;

        Player player = new Player(200, 400);
        public GameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//پرش صفحه نداریم دیگه با این خط
            this.KeyPreview = true;

        }
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


            // نشون دادن تایم باقی مونده از پاور اپ
            if (player.ShieldTimer > 0)
            {
                int secondsLeft = (player.ShieldTimer / 60) + 1; // تبدیل تیک تایمر به ثانیه
                e.Graphics.DrawString("Shield: " + secondsLeft + "s", new Font("Arial", 12, FontStyle.Bold), Brushes.Cyan, new Point(10,130));
                
            }

            if (player.TripleShotTimer > 0)
            {
                int secondsLeft = (player.TripleShotTimer / 60) + 1;
                e.Graphics.DrawString("Triple Shot: " + secondsLeft + "s", new Font("Arial", 12, FontStyle.Bold), Brushes.Orange, new Point(10,160));
            }

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

            foreach (var c in coinsList) ((Coin)c).Draw(e.Graphics);

            e.Graphics.DrawString("Coins: " + sessionCoins, new Font("Arial", 16, FontStyle.Bold), Brushes.Yellow, new Point(10, 100));

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Left) isMovingLeft = true;
            if (e.KeyCode == Keys.Right) isMovingRight = true;
            if (e.KeyCode == Keys.Up) isMovingUp = true;
            if (e.KeyCode == Keys.Down) isMovingDown = true;
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
            if (e.KeyCode == Keys.Up) isMovingUp = false;
            if (e.KeyCode == Keys.Down) isMovingDown = false;
            if (e.KeyCode == Keys.Space) isShooting = false;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isGameOver) return;

            if (player.ShieldTimer > 0) player.ShieldTimer--;
            if (player.TripleShotTimer > 0) player.TripleShotTimer--;

            
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

            foreach (var pw in powerUps)
            {
                ((PowerUp)pw).Move();
            }


            foreach (var c in coinsList)
            {
                ((Coin)c).Move();
            }

            if (isMovingLeft) player.MoveLeft();
            if (isMovingRight) player.MoveRight(this.ClientSize.Width);
            if (isMovingUp) player.MoveUp();
            if (isMovingDown) player.MoveDown(this.ClientSize.Height);

            if (shootCooldown > 0) shootCooldown--;

            if (isShooting && shootCooldown == 0)
            {
                // ۱. ابتدا اسکین تیر فعال را از دیتابیس می‌خوانیم
                int activeBulletSkin = DatabaseManager.GetSkin("BulletSkin");

                if (player.TripleShotTimer > 0)
                {
                    Bullet b1 = new Bullet(player.X - 10, player.Y);
                    Bullet b2 = new Bullet(player.X + 20, player.Y);
                    Bullet b3 = new Bullet(player.X + 50, player.Y);

                    // اعمال اسکین خریداری شده
                    b1.SkinType = activeBulletSkin;
                    b2.SkinType = activeBulletSkin;
                    b3.SkinType = activeBulletSkin;

                    bullets.Add(b1);
                    bullets.Add(b2);
                    bullets.Add(b3);
                }
                else
                {
                    Bullet b = new Bullet(player.X + 20, player.Y);

                    // اعمال اسکین خریداری شده
                    b.SkinType = activeBulletSkin;

                    bullets.Add(b);
                }
                if (!GameSettings.IsSFXMuted)
                {
                    new System.Media.SoundPlayer(Properties.Resources.snd_shoot).Play();
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
                            if (!GameSettings.IsSFXMuted)
                            {
                                new System.Media.SoundPlayer(Properties.Resources.snd_boom).Play();
                            }
                            score += hitEnemy.EnemyScore;
                            enemiesDefeatedInWave++;
                            enemiesToRemove.Add(e);
                            //منطق احتمال افتادن سکه ها
                            int dropChance = rnd.Next(0, 100);
                            int threshold = 30 + (currentWave * 2);

                            if (dropChance < threshold)
                            {
                                if (hitEnemy is HeavyTankEnemy || rnd.Next(0, 10) > 5)
                                {
                                    coinsList.Add(new GoldCoin(hitEnemy.X, hitEnemy.Y));
                                }
                                else
                                {
                                    coinsList.Add(new SilverCoin(hitEnemy.X, hitEnemy.Y));
                                }
                            }

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
                                // ذخیره در دیتابیس
                                DatabaseManager.SaveGameResult(score, sessionCoins);
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
                    enemiesToRemove.Add(e);

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
                // ذخیره در دیتابیس
                DatabaseManager.SaveGameResult(score, sessionCoins);
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

            //برخورد با سکه ها
            var coinsToRemove = new List<GameObject>();

            foreach (var c in coinsList)
            {
                Rectangle cRect = new Rectangle(c.X, c.Y, c.Width, c.Height);

                if (cRect.IntersectsWith(playerRect))
                {
                    if (!GameSettings.IsSFXMuted)
                    {
                        new System.Media.SoundPlayer(Properties.Resources.snd_coin).Play();
                    }
                    sessionCoins += ((Coin)c).Value;
                    coinsToRemove.Add(c);
                }
                else if (c.Y > this.ClientSize.Height)
                {
                    coinsToRemove.Add(c);
                }
            }

            foreach (var c in coinsToRemove) coinsList.Remove(c);

        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            if (!GameSettings.IsMusicMuted)
            {
                System.Media.SoundPlayer bgMusic = new System.Media.SoundPlayer(Properties.Resources.snd_bg);
                bgMusic.PlayLooping();
            }

            // خواندن تعداد جان‌های اضافه از دیتابیس و اضافه کردن به سفینه بازیکن
            int extraHP = DatabaseManager.GetExtraHP();
            player.MaxHP += extraHP;
            player.HP = player.MaxHP;

            // تنظیم سفینه
            player.SkinType = DatabaseManager.GetSkin("ShipSkin");

            // تنظیم پس‌زمینه بازی
            int bgType = DatabaseManager.GetSkin("BgSkin");

            if (bgType == 1)
            {
                this.BackgroundImage = Properties.Resources.bg_mars;
            }
            else if (bgType == 2)
            {
                this.BackgroundImage = Properties.Resources.bg_galaxy;
            }
            else
            {
                this.BackgroundImage = null;
                this.BackColor = Color.White;
            }
        }
    }
}
