using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace CapCube
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D bgTexture;
        Texture2D sprite;
        int displayH;
        int displayW;
        int scale = 1;

        int curPosY = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //graphics.PreferredBackBufferWidth = 640*scale;
            //graphics.PreferredBackBufferHeight = 360*scale;
            //graphics.PreferMultiSampling = false;
            //graphics.ApplyChanges();

            IsMouseVisible = true;
            displayH = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            displayW = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

            // Change Virtual Resolution
            Resolution.Init(ref graphics);
            Resolution.SetVirtualResolution(480, 270); //game resolution //640, 360
            Resolution.SetResolution(480, 270, false); //window resolution



        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            SceneManager.SetScene(SceneManager.Scenes.Start);

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameUtils.Init(spriteBatch, Content);

            // TODO: use this.Content to load your game content here

            //bgTexture = Content.Load<Texture2D>("Graphics/Battlebacks/bg_start");
            //sprite = Content.Load<Texture2D>("Graphics/Battlers/030");
            
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            SceneManager.Update();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.NumPad1))
            {
                Resolution.ToggleFullScreen();
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            Matrix mScale = Matrix.CreateScale(new Vector3(scale, scale, 1));
            //spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp, null, null, null, mScale);

            Resolution.BeginDraw();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, Resolution.getTransformationMatrix());
            SceneManager.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
