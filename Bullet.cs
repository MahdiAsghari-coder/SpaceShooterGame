using System.Drawing;
using SpaceShooterGame.Properties; // برای دسترسی به عکس‌های ریسورسز

namespace SpaceShooterGame
{
    public class Bullet : GameObject
    {

        public int SkinType { get; set; } = 0;

        public Bullet(int x, int y)
        {
            X = x;
            Y = y;
            Width = 10;
            Height = 20;
        }

        public override void Draw(Graphics g)
        {
            if (SkinType == 1)
                g.DrawImage(Properties.Resources.bullet_plasma, X, Y, Width, Height);
            else if (SkinType == 2)
                g.DrawImage(Properties.Resources.bullet_green, X, Y, Width, Height);
            else
                g.DrawImage(Properties.Resources.bullet_player, X, Y, Width, Height);
        }

        public void MoveUp()
        {
            Y -= 10; // حرکت به سمت بالا با سرعت ۱۰ پیکسل
        }
    }
}
