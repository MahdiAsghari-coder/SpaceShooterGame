using System.Drawing;
using System.Collections.Generic;

namespace SpaceShooterGame
{
    public class ShooterEnemy : Enemy
    {
        private int shootTimer = 0;

        public ShooterEnemy(int x, int y) : base(x, y, 40, 40)
        {
            HP = 3;
        }

        public override void Move(int playerX, int playerY)
        {
            Y += 2;
        }

        public override void Shoot(List<GameObject> enemyBullets)
        {
            shootTimer++;
            if (shootTimer >= 75)
            {
                enemyBullets.Add(new EnemyBullet(X + Width / 2 - 5, Y + Height, 0, 5));
                shootTimer = 0;
            }
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(global::SpaceShooterGame.Properties.Resources.enemy_shooter, X, Y, Width, Height);
        }
    }
}