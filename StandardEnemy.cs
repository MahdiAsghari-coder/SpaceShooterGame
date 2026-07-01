using System.Drawing;

namespace SpaceShooterGame
{
    public class StandardEnemy : Enemy
    {
        public StandardEnemy(int x, int y) : base(x, y, 40, 40)
        {
            HP = 1;
        }

        public override void Move()
        {
            Y += 3;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(global::SpaceShooterGame.Properties.Resources.enemy_standard, X, Y, Width, Height);
        }
    }
}