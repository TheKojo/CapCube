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
    class SpecterSprite : Sprite
    {
        Specter Specter;
        public Sprite Sprite;
        public CCSpecterState.State State = CCSpecterState.State.Stand;

        public SpecterSprite(Specter specter)
        {
            Specter = specter;
            SetTexture("Graphics/Battlers/" + Specter.Species + "_" + State);
            SourceRectangle = new Rectangle(0, 0, Texture.Height, Texture.Height);
            SetOrigin(SpriteOrigin.Bottom);
        }


        public override void SetPosition(float x, float y)
        {
            int multi = 1;
            if (Effect == SpriteEffects.FlipHorizontally)
            {
                multi = -1;
            }
            Position = new Vector2(x+GameUtils.GetSpecter(Specter.Species).SpriteOffsetX*multi, y+GameUtils.GetSpecter(Specter.Species).SpriteOffsetY);
        }

    }
    
}
