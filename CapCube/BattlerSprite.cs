using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace CapCube
{
    class BattlerSprite
    {
        private Specter Specter;
        public SpecterSprite SpecterSprite;
        public GaugeSprite BattlerGaugeSprite;
        public Sprite ShadowSprite = new Sprite("Graphics/GUI/shadow");

        public BattlerSprite(Specter specter)
        {
            Specter = specter;
            SpecterSprite = new SpecterSprite(Specter);
            BattlerGaugeSprite = new GaugeSprite(Specter);
            ShadowSprite.SetOrigin(Sprite.SpriteOrigin.Center);
        }

        public void Update()
        {
            SpecterSprite.Update();
        }

        public void Draw()
        {
            ShadowSprite.Draw();
            SpecterSprite.Draw();
            BattlerGaugeSprite.Draw();

        }

        public void SetPosition(float X, float Y)
        {
            SpecterSprite.SetPosition(X, Y);
            BattlerGaugeSprite.SetPosition(X-28, Y + 8);
            ShadowSprite.SetPosition(X, Y);
        }

        public void Flip()
        {
            SpecterSprite.SetEffect(SpriteEffects.FlipHorizontally);
        }



    }
}
