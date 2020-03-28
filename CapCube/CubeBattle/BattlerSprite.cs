using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
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

        public void Update(GameTime gameTime)
        {
            SpecterSprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            ShadowSprite.Draw(gameTime);
            SpecterSprite.Draw(gameTime);
            BattlerGaugeSprite.Draw(gameTime);

        }

        public void SetPosition(float X, float Y)
        {
            SpecterSprite.SetPosition(X, Y);
            BattlerGaugeSprite.SetPosition(X - 28, Y + 8);
            ShadowSprite.SetPosition(X, Y);
        }

        public void SetPosition(Vector2 position)
        {
            SetPosition(position.X, position.Y);
        }

        public void Flip()
        {
            SpecterSprite.SetEffect(SpriteEffects.FlipHorizontally);
        }

        public void ChangeState(CCSpecterState.State newState)
        {
            SpecterSprite.SetTexture("Graphics/Battlers/" + Specter.Species + "_" + newState);
            switch (newState)
            {
                case CCSpecterState.State.Stand:
                    SpecterSprite.TimeToUpdate = 50;
                    break;
                case CCSpecterState.State.Walk:
                    SpecterSprite.TimeToUpdate = 40;
                    break;
                case CCSpecterState.State.AttackFar:
                    SpecterSprite.TimeToUpdate = 20;
                    break;
            }
        }
    }
}
