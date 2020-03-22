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
    class GaugeSprite : Sprite
    {
        private Specter Specter;
        public Sprite HPSprite = new Sprite("Graphics/GUI/hpbars");
        public Sprite PPSprite = new Sprite("Graphics/GUI/ppbar");
        
        public GaugeSprite(Specter specter) : base ("Graphics/GUI/gauge")
        {
            Specter = specter;
            Rectangle hpRec = new Rectangle(0, 0, 43, 4);
            HPSprite.SourceRectangle = hpRec;
            HPSprite.SetPosition(X + 10, Y + 1);

            PPSprite.SetPosition(X + 10, Y + 6);

        }

        public override void SetPosition(float x, float y)
        {
            base.SetPosition(x, y);
            HPSprite.SetPosition(X + 10, Y + 1);
            PPSprite.SetPosition(X + 10, Y + 6);
        }

        public override void Draw()
        {
            base.Draw();
            HPSprite.Draw();
            PPSprite.Draw();
        }
    }
}
