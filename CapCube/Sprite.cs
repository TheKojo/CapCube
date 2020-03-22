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
        public int TimeToUpdate = 0; //the higher this is, the slower the animation
        private int _updateCounter = 0;

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

        public virtual void Update()
        {
            if (IsAnimated)
            {
                if (_updateCounter == TimeToUpdate) {
                    _updateCounter = 0;
                    _frameCounter++;
                    if (_frameCounter == FramesCount)
                    {
                        _frameCounter = 0;
                    }
                    SourceRectangle.X = _frameCounter * SourceRectangle.Width;
                }
                else
                {
                    _updateCounter++;
                }
            }
        }

        public virtual void Draw()
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
            }
            else
            {
                SourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
                FramesCount = 1;
            }
            _updateCounter = 0;
            _frameCounter = 0;
        }

        public virtual void SetPosition(float x, float y)
        {
            Position = new Vector2(x, y);
        }

        public float X
        {
            get { return Position.X; }
            
        }

        public float Y
        {
            get { return Position.Y; }
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
    }
}
