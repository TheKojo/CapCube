using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CapCube
{
    static class SceneManager
    {
        static Scene ActiveScene;
        static ContentManager Content;
        public enum Scenes
        {
            Start,
            Battle
        } 

        static public void SetScene(Scenes scene)
        {
            switch (scene)
            {
                case Scenes.Start:
                    ActiveScene = new SceneStart();
                    break;
                case Scenes.Battle:
                    ActiveScene = new SceneBattle();
                    break;

            }
            
            //ActiveScene.StartScene();
        }

        static public void SetScene(Scenes sceneType, Scene scene)
        {
            ActiveScene = scene;
        }

        static public void Update()
        {
            ActiveScene.Update();
        }

        static public void Draw()
        {
            ActiveScene.Draw();
        }

        static public void StartWildBattle(int numOpponents)
        {
            ActiveScene = new SceneBattle();
        }
    }
}
