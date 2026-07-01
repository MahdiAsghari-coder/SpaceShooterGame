using System.Drawing;
using System.Collections.Generic;

namespace SpaceShooterGame
{
    public class HeavyTankEnemy : Enemy
    {
        private int shootTimer = 0;

        public HeavyTankEnemy(int x, int y) : base(x, y, 80, 80) // سایز بزرگتر
        {
            HP = 20;
        }

        public override void Move(int playerX, int playerY)
        {
            Y += 1;
        }

        public override void Shoot(List<GameObject> enemyBullets)
        {
            shootTimer++;
            if (shootTimer >= 100)
            {
                int cX = X + Width / 2 - 5;
                int cY = Y + Height / 2;

                enemyBullets.Add(new EnemyBullet(cX, cY, 0, 5));   // پایین
                enemyBullets.Add(new EnemyBullet(cX, cY, 0, -5));  // بالا
                enemyBullets.Add(new EnemyBullet(cX, cY, 5, 0));   // راست
                enemyBullets.Add(new EnemyBullet(cX, cY, -5, 0));  // چپ
                enemyBullets.Add(new EnemyBullet(cX, cY, 4, 4));   // پایین-راست
                enemyBullets.Add(new EnemyBullet(cX, cY, -4, 4));  // پایین-چپ
                enemyBullets.Add(new EnemyBullet(cX, cY, 4, -4));  // بالا-راست
                enemyBullets.Add(new EnemyBullet(cX, cY, -4, -4)); // بالا-چپ

                shootTimer = 0;
            }
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(global::SpaceShooterGame.Properties.Resources.enemy_heavytank, X, Y, Width, Height);
        }
    }
}