using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CapCube
{
    class Sprite
    {
        public Texture2D Texture = null;
        public Vector2 Position = new Vector2(0, 0);
        public Rectangle SourceRectangle;
        public Vector2 Origin = new Vector2(0, 0);
        public Vector2 Offset = new Vector2(0, 0);
        public float Rotation = 0;
        public Vector2 Scale = new Vector2(1, 1);
        public Color Color = Color.White;
        public SpriteEffects Effect = SpriteEffects.None;
        public float LayerDepth = 0;
        public int FramesCount = 0;
        private int _frameCounter = 0;
        public bool IsAnimated = false;
        public float TimeToUpdate = 50; //the higher this is, the slower the animation
        private float _updateCounter = 0;
        public bool IsPaused = false;
        public bool PlayOnce = false;
        public bool ReverseOnce = false;

        public Sprite()
        {

        }

        public Sprite(string filename, bool animated = false)
        {
            Texture = GameUtils.Content.Load<Texture2D>(filename);
            IsAnimated = animated;
            if (IsAnimated)
            {
                SourceRectangle = new Rectangle(0, 0, Texture.Height, Texture.Height);
                FramesCount = Texture.Width / Texture.Height;
            }
            else
            {
                SourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
                FramesCount = 1;
            }
            
        }

        public virtual void Update(GameTime gameTime)
        {
             float ms = (float) gameTime.ElapsedGameTime.TotalMilliseconds;
            _updateCounter += ms;
            if (IsAnimated && !IsPaused)
            {
                if (_updateCounter >= TimeToUpdate) {
                    _updateCounter = 0;
                    if (ReverseOnce)
                    {
                        _frameCounter--;
                        if (_frameCounter == 0)
                        {
                            IsPaused = true;
                            ReverseOnce = false;
                        }
                    }
                    else
                    {
                        _frameCounter++;
                    }
                    if (_frameCounter == FramesCount && !PlayOnce)
                    {
                        _frameCounter = 0;
                    }
                    if (_frameCounter == FramesCount-1 && PlayOnce)
                    {
                        IsPaused = true;
                        PlayOnce = false;
                    }
                    SourceRectangle.X = _frameCounter * SourceRectangle.Width;
                }
            }
        }


        public virtual void Draw(GameTime gameTime)
        {
            GameUtils.SpriteBatch.Draw(Texture, Position, SourceRectangle, Color, Rotation, Origin, Scale, Effect, LayerDepth);
        }

        public void SetTexture(string filename)
        {
            Texture = GameUtils.Content.Load<Texture2D>(filename);
            if (IsAnimated)
            {
                SourceRectangle = new Rectangle(0, 0, Texture.Height, Texture.Height);
                FramesCount = Texture.Width / Texture.Height;
                IsPaused = false;
            }
            else
            {
                SourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
                FramesCount = 1;
            }
            _updateCounter = 0;
            _frameCounter = 0;
            PlayOnce = false;
            ReverseOnce = false;
        }

        public virtual void SetPosition(float x, float y)
        {
            Position = new Vector2(x, y);
        }

        public virtual void SetPosition(Vector2 position)
        {
            SetPosition(position.X, position.Y);
        }

        public float X
        {
            get { return Position.X; }
            
        }

        public float Y
        {
            get { return Position.Y; }
        }

        public int Width
        {
            get { return SourceRectangle.Width; }
        }

        public int Height
        {
            get { return SourceRectangle.Height; }
        }


        public void DrawSimple()
        {
            GameUtils.SpriteBatch.Draw(Texture, Position, Color);
        }

        public void SetOrigin(SpriteOrigin origin)
        {
            switch (origin)
            {
                case SpriteOrigin.TopLeft:
                    Origin = new Vector2(0, 0);
                    break;
                case SpriteOrigin.Top:
                    break;
                case SpriteOrigin.TopRight:
                    break;
                case SpriteOrigin.Left:
                    break;
                case SpriteOrigin.Center:
                    Origin = new Vector2(SourceRectangle.Width / 2, SourceRectangle.Height / 2);
                    break;
                case SpriteOrigin.Right:
                    break;
                case SpriteOrigin.BottomLeft:
                    break;
                case SpriteOrigin.Bottom:
                    Origin = new Vector2(SourceRectangle.Width / 2, SourceRectangle.Height);
                    break;
                case SpriteOrigin.BottomRight:
                    break;
            }
        }

        public enum SpriteOrigin
        {
            TopLeft,
            Top,
            TopRight,
            Left,
            Center,
            Right,
            BottomLeft,
            Bottom,
            BottomRight
        }

        public void SetEffect(SpriteEffects effect)
        {
            Effect = effect;
        }

        public void SetSourceRectangle(Rectangle frameRect, bool animate = false)
        {
            SourceRectangle = frameRect;
            IsAnimated = animate;
            if (IsAnimated)
            {
                FramesCount = Texture.Width / Texture.Height;
            }
            else
            {
                FramesCount = 1;
            }
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Start()
        {
            IsPaused = false;
        }

        public void PlayAndStop()
        {
            PlayOnce = true;
        }

        public void ReverseAndStop()
        {
            ReverseOnce = true;
        }
    }
}
