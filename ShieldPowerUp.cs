using System.Drawing;
namespace SpaceShooterGame
{
    public class ShieldPowerUp : PowerUp
    {
        public ShieldPowerUp(int x, int y) : base(x, y) { }
        public override void ApplyEffect(Player player)
        {
            player.ShieldTimer = 250;
        }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Cyan, X, Y, Width, Height);
        }
    }
}