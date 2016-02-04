using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter
{
    public class Bullet
    {
        private List<Bullet> bullets = new List<Bullet>();
        public List<Bullet> Bullets { get { return bullets; } }

        private int x, y;          

        public Bullet(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Add(Bullet b)
        {
           bullets.Add(b);
        }

        public void Draw()
        {
            foreach (Bullet b in bullets)
            {
                // TODO: Add drawing code
            }     
        }
    }
}
