using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CapCube
{
    class Skill
    {
        public Battler User;
        int SkillID;
        public decimal DamagePercent = 1;
        public bool Done = false;
        public bool IsCasting = true;
        public bool IsDelayed = false;
        public float CastTime = 200; //time before move comes out 
        public float DelayTime = 200; //time user is stuck after casting
        Sprite Projectile;
        public float ProjectileSpeed = 5;
        private float _updateCounter = 0;
        private SpecterSprite _sSprite;

        public Skill(Battler user, int skillID)
        {
            User = user;
            SkillID = skillID;
            UseSkill4();
        }

        //Larvuzz Basic Attack
        public void UseSkill4()
        {
            //Projectile = new Sprite("Graphics/SkillAnimations/projectile4");
            _sSprite = User.BattlerSprite.SpecterSprite;
            //Projectile.SetPosition(_sSprite.X + _sSprite.Width/2, _sSprite.Y - _sSprite.Height/2);
            User.BattlerSprite.ChangeState(CCSpecterState.State.AttackFar);
            _sSprite.TimeToUpdate = CastTime / _sSprite.FramesCount;
            _sSprite.PlayAndStop();
        }

        public void Update(GameTime gameTime)
        {
            float ms = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            _updateCounter += ms;
            if (_updateCounter >= CastTime && IsCasting) //Cast
            {
                _updateCounter = 0;
                IsCasting = false;
                IsDelayed = true;
                _sSprite.ReverseAndStop();
                _sSprite.TimeToUpdate = DelayTime / _sSprite.FramesCount;
                _sSprite.Start();

            }
            else if (_updateCounter >= DelayTime && !IsCasting && IsDelayed) //Delay
            {
                _updateCounter = 0;
                IsDelayed = false;
                User.BattlerSprite.ChangeState(CCSpecterState.State.Stand);
                _sSprite.Start();
                User.IsAttacking = false;
            }
            else if (!IsCasting && !Done)
            {
                User.Battle.AddProjectile(new Projectile(this));
                //Projectile.SetPosition(Projectile.X + ProjectileSpeed, Projectile.Y);
                //if (Projectile.X > 500) // || damaged something
                //{
                    Done = true;
                //}
            }

            //User.Battle.AddProjectile()
        }

        public void Draw(GameTime gameTime)
        {
            //if (!IsCasting)
            //{
                //Projectile.Draw(gameTime);
            //}
            
        }

    }
}
