using System.Drawing;
using System.Collections.Generic;

namespace SpaceShooterGame
{
    public abstract class Enemy : GameObject
    {
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Speed { get; set; }
        public int EnemyScore { get; set; }

        public Enemy(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public abstract void Move(int playerX, int playerY);

        public virtual void Shoot(List<GameObject> enemyBullets) { }
    }
}