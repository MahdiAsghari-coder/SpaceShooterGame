using System.Drawing;
namespace SpaceShooterGame
{
    public class HealthPowerUp : PowerUp
    {
        public HealthPowerUp(int x, int y) : base(x, y) { }
        public override void ApplyEffect(Player player)
        {
            if (player.HP < player.MaxHP) player.HP += 1;
        }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.LimeGreen, X, Y, Width, Height);
        }
    }
}