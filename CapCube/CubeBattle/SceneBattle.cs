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
    class SceneBattle : Scene
    {
        int curPosY = 0;
        Battle Battle;
        bool WPressed = false;
        bool APressed = false;
        bool SPressed = false;
        bool DPressed = false;
        bool SpacePressed = false;

        public SceneBattle()
        {

        }

        //Wild Battle
        public SceneBattle(List<Specter> opponents)
        {
            SceneManager.SetScene(SceneManager.Scenes.Battle, this);
            BackgroundTexture = GameUtils.Content.Load<Texture2D>("Graphics/Battlebacks/bg_training2");
            Battle = new Battle(opponents);
        }

        //Trainer Battle
        public SceneBattle(Trainer opponent)
        {
            SceneManager.SetScene(SceneManager.Scenes.Battle, this);
            BackgroundTexture = GameUtils.Content.Load<Texture2D>("Graphics/Battlebacks/bg_grass");
            Battle = new Battle(opponent);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W)) //&& !WPressed)
            {
                WPressed = true;
                //APressed = false;
                //SPressed = false;
                //DPressed = false;
                //SpacePressed = false;
                Battle.ActiveBattlers[0].Move(0, -1);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A)) //&& !APressed)
            {
                //WPressed = false;
                APressed = true;
                //SPressed = false;
                //DPressed = false;
                //SpacePressed = false;
                Battle.ActiveBattlers[0].Move(-1, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S)) //&& !SPressed)
            {
                //WPressed = false;
                //APressed = false;
                SPressed = true;
                //DPressed = false;
                //SpacePressed = false;
                Battle.ActiveBattlers[0].Move(0, 1);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D)) //&& !DPressed)
            {
                //WPressed = false;
                //APressed = false;
                //SPressed = false;
                DPressed = true;
                //SpacePressed = false;
                Battle.ActiveBattlers[0].Move(1, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space)) //&& !SpacePressed)
            {
                //WPressed = false;
                //APressed = false;
                //SPressed = false;
                //DPressed = false;
                SpacePressed = true;
                Battle.ActiveBattlers[0].BasicAttack();
            }

            if (Keyboard.GetState().IsKeyUp(Keys.W))
            {
                WPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.A))
            {
                APressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.S))
            {
                SPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.D))
            {
                DPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                SpacePressed = false;
            }

            foreach (Battler i in Battle.ActiveBattlers)
            {
                i.Update(gameTime);
            }

            Battle.Field.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameUtils.SpriteBatch.Draw(BackgroundTexture, new Vector2(0, 0), Color.White);
            for (int i = 0; i<Battle.ActiveBattlers.Count; i++)
            {
                Battle.ActiveBattlers[i].Draw(gameTime);
            }

            Battle.Field.Draw(gameTime);
        }

    }

}
