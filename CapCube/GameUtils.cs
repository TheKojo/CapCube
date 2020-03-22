using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace CapCube
{
    static class GameUtils
    {
        static public SpriteBatch SpriteBatch = null;
        static public ContentManager Content = null;
        static public List<CapCubeData.Specter> Specters = null;
        static public Trainer Player = null;

        static public void Init(SpriteBatch spriteBatch, ContentManager contentManager)
        {
            SpriteBatch = spriteBatch;
            Content = contentManager;
            Specters = Content.Load<List<CapCubeData.Specter>>("Data/specters");
            Player = new Trainer("Pink", CCGender.Gender.Male);
            Player.AddSpecter(new Specter(4, 5));
        }

        static public CapCubeData.Specter GetSpecter(int species)
        {
            return Specters[species-1];
        }


    }
}
