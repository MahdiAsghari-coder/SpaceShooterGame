using System.Drawing;

namespace SpaceShooterGame
{
    public abstract class Enemy : GameObject
    {
        public int HP { get; set; }

        public Enemy(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public abstract void Move();
    }
}