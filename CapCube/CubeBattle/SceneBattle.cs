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

        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (!WPressed)
                {
                    WPressed = true;
                    Battle.ActiveBattlers[0].Move(0, -1);
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (!APressed)
                {
                    APressed = true;
                    Battle.ActiveBattlers[0].Move(-1, 0);
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (!SPressed)
                {
                    SPressed = true;
                    Battle.ActiveBattlers[0].Move(0, 1);
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (!DPressed)
                {
                    DPressed = true;
                    Battle.ActiveBattlers[0].Move(1, 0);
                }
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

            foreach (Battler i in Battle.ActiveBattlers)
            {
                i.Update();
            }
        }

        public override void Draw()
        {
            
            //SpriteBatch sBatch = GameUtils.SpriteBatch;
            GameUtils.SpriteBatch.Draw(BackgroundTexture, new Vector2(0, 0), Color.White);
            for (int i = 0; i<Battle.ActiveBattlers.Count; i++)
            {
                Battle.ActiveBattlers[i].Draw();
            }
        }

    }

}
