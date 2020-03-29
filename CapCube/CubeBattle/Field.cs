using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CapCube
{
    class Field
    {
        Tile[,] tiles = new Tile[3, 9];
        public List<Projectile> ActiveProjectiles = new List<Projectile>();

        public void Update(GameTime gameTime)
        {
            foreach (Projectile i in ActiveProjectiles)
            {
                i.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime)
        {
            foreach (Projectile i in ActiveProjectiles)
            {
                i.Draw(gameTime);
            }
        }
    }
}
