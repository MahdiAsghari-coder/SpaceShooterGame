using System.Drawing;
namespace SpaceShooterGame
{
    public class TripleShotPowerUp : PowerUp
    {
        public TripleShotPowerUp(int x, int y) : base(x, y) { }
        public override void ApplyEffect(Player player)
        {
            player.TripleShotTimer = 500;
        }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Orange, X, Y, Width, Height);
        }
    }
}