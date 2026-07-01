using System;
using System.Drawing;

namespace SpaceShooterGame
{
    public class ScoutEnemy : Enemy
    {
        private int startX;
        private double angle = 0;

        public ScoutEnemy(int x, int y) : base(x, y, 40, 40)
        {
            HP = 1;
            startX = x;
        }

        public override void Move()
        {
            Y += 5;
            angle += 0.15;
            X = startX + (int)(Math.Sin(angle) * 60);
        }

        public override void Draw(Graphics g)
        {
            // فعلاً از همون عکس استاندارد استفاده میکنیم، بعدا میتونی عکس متفاوتی براش تو Resources بذاری
            g.DrawImage(global::SpaceShooterGame.Properties.Resources.enemy_scout, X, Y, Width, Height);
        }
    }
}