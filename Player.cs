using System.Drawing;
using SpaceShooterGame.Properties;

namespace SpaceShooterGame
{
    public class Player : GameObject
    {
        public int Speed { get; set; } = 10;
        public int HP { get; set; } = 3;
        public int MaxHP { get; set; } = 3;
        public int ShieldTimer { get; set; } = 0;
        public int TripleShotTimer { get; set; } = 0;

        public int SkinType { get; set; } = 0;

        public Player(int x, int y)
        {
            X = x;
            Y = y;
            Width = 50;
            Height = 50;
        }

        public override void Draw(Graphics g)
        {
            // رسم ظاهر سفینه بر اساس خرید کاربر
            if (SkinType == 1)
                g.DrawImage(Properties.Resources.ship_eagle, X, Y, Width, Height);
            else if (SkinType == 2)
                g.DrawImage(Properties.Resources.ship_ghost, X, Y, Width, Height);
            else
                g.DrawImage(Properties.Resources.player_ship, X, Y, Width, Height);
        }

        public void MoveLeft()
        {
            if (X > 0) X -= Speed;
        }
        public void MoveRight(int formWidth) 
        { 
            if (X < formWidth - Width) X += Speed;
        }
    }
}