using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CapCube
{
    class Projectile
    {
        Battler User;
        private SpecterSprite _sSprite;
        Sprite ProjectileSprite;
        int Speed;
        int Direction;
        public decimal DamagePercent;
        public bool Done = false;
        private float _updateCounter;
        Vector2 ActiveTilePos = new Vector2(0, 0);

        public Projectile(Skill skill)
        {
            User = skill.User;
            ProjectileSprite = new Sprite("Graphics/SkillAnimations/projectile4");
            Speed = 5;
            DamagePercent = 1;
            _sSprite = User.BattlerSprite.SpecterSprite;
            ProjectileSprite.SetPosition(_sSprite.X + _sSprite.Width / 2, _sSprite.Y - _sSprite.Height / 2);
        }

        public void Update(GameTime gameTime)
        {
            ProjectileSprite.SetPosition(ProjectileSprite.X + Speed, ProjectileSprite.Y);
            if (ProjectileSprite.X >=  && Direction == 1)
            {

            }

            if (ProjectileSprite.X > 500) // || damaged something
            {
                Done = true;
            }
        }

        public void Draw(GameTime gameTime)
        {
            ProjectileSprite.Draw(gameTime);
        }
    }
}
