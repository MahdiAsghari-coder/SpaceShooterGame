using System.Drawing;

namespace SpaceShooterGame
{
    public class TerroristEnemy : Enemy
    {
        public TerroristEnemy(int x, int y) : base(x, y, 40, 40)
        {
            HP = 5;
            MaxHP = HP;
            Speed = 1;
            EnemyScore = 30;
        }

        public override void Move(int playerX, int playerY)
        {
            if (X < playerX) X += 2;
            else if (X > playerX) X -= 2;

            Y += Speed;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(global::SpaceShooterGame.Properties.Resources.enemy_terrorist, X, Y, Width, Height);
        }
    }
}