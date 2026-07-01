using SpaceShooterGame;
using System.Drawing;
using SpaceShooterGame.Properties;

public class Enemy : GameObject
{
    public Enemy(int x, int y)
    {
        X = x;
        Y = y;
        Width = 40;
        Height = 40;
    }

    public override void Draw(Graphics g)
    {
        g.DrawImage(global::SpaceShooterGame.Properties.Resources.enemy_standard, X, Y, Width, Height);
    }
}