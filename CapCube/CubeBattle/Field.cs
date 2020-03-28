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
        public List<Skill> ActiveSkills = new List<Skill>();

        public void Update(GameTime gameTime)
        {
            foreach (Skill i in ActiveSkills)
            {
                i.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime)
        {
            foreach (Skill i in ActiveSkills)
            {
                i.Draw(gameTime);
            }
        }
    }
}
