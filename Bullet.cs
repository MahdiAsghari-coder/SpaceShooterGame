using System.Drawing;
using SpaceShooterGame.Properties; // برای دسترسی به عکس‌های ریسورسز

namespace SpaceShooterGame
{
    public class Bullet : GameObject
    {
        public Bullet(int x, int y)
        {
            X = x;
            Y = y;
            Width = 10;
            Height = 20;
        }

        public override void Draw(Graphics g)
        {
            // رسم گلوله بازیکن
            g.DrawImage(global::SpaceShooterGame.Properties.Resources.bullet_player, X, Y, Width, Height);
        }

        public void MoveUp()
        {
            Y -= 10; // حرکت به سمت بالا با سرعت ۱۰ پیکسل
        }
    }
}
