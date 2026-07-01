using System.Drawing;

namespace SpaceShooterGame
{
    public class EnemyBullet : GameObject
    {
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }

        public EnemyBullet(int x, int y, int speedX, int speedY)
        {
            X = x;
            Y = y;
            Width = 10;
            Height = 20;
            SpeedX = speedX;
            SpeedY = speedY;
        }

        public void Move()
        {
            X += SpeedX;
            Y += SpeedY;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(global::SpaceShooterGame.Properties.Resources.bullet_enemy, X, Y, Width, Height);
        }
    }
}