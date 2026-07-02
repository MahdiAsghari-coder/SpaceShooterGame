using System.Drawing;

namespace SpaceShooterGame
{
    public class StandardEnemy : Enemy
    {
        public StandardEnemy(int x, int y) : base(x, y, 40, 40)
        {
            HP = 1;
            MaxHP = HP;
            Speed = 3;
            EnemyScore = 10;
        }

        public override void Move(int playerX, int playerY)
        {
            Y += Speed;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(global::SpaceShooterGame.Properties.Resources.enemy_standard, X, Y, Width, Height);
        }
    }
}