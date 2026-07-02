using System.Drawing;

namespace SpaceShooterGame
{
    public abstract class PowerUp : GameObject
    {
        public PowerUp(int x, int y)
        {
            X = x;
            Y = y;
            Width = 20;
            Height = 20;
        }

        public void Move()
        {
            Y += 3;
        }

        public abstract void ApplyEffect(Player player);
    }
}