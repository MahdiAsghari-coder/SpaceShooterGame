using System.Drawing;

namespace SpaceShooterGame
{
    public abstract class Coin : GameObject
    {
        public int Value { get; set; }
        public int Speed { get; set; } = 3;

        public void Move()
        {
            Y += Speed;
        }
    }

    public class SilverCoin : Coin
    {
        public SilverCoin(int x, int y)
        {
            X = x; Y = y; Width = 15; Height = 15; Value = 1;
        }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Silver, X, Y, Width, Height);
            g.DrawEllipse(Pens.White, X, Y, Width, Height);
        }
    }

    public class GoldCoin : Coin
    {
        public GoldCoin(int x, int y)
        {
            X = x; Y = y; Width = 20; Height = 20; Value = 5;
        }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Gold, X, Y, Width, Height);
            g.DrawEllipse(Pens.Orange, X, Y, Width, Height);
        }
    }
}