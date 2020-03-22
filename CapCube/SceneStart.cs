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
    class SceneStart : Scene
    {
        private SpriteFont font;

        public SceneStart()
        {
            font = GameUtils.Content.Load<SpriteFont>("Fonts/FL");
            BackgroundTexture = GameUtils.Content.Load<Texture2D>("Graphics/Battlebacks/bg_start");
        }


        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                //SceneManager.SetScene(SceneManager.Scenes.Battle);
                List<Specter> opponents = new List<Specter>();
                opponents.Add(new Specter(4, 3));
                SceneBattle battleScene = new SceneBattle(opponents);
            }
        }

        public override void Draw()
        {
            GameUtils.SpriteBatch.Draw(BackgroundTexture, new Vector2(0, 0), Color.White);
            GameUtils.SpriteBatch.DrawString(font, "Press Enter", new Vector2(100, 100), Color.White);
        }

        public void StartGame()
        {

        }
    }
}
