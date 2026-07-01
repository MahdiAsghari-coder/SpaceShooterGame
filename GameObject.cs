using System.Drawing;

namespace SpaceShooterGame
{
    public abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public abstract void Draw(Graphics g);
    }
}