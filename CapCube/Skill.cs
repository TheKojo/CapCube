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
        Battler User;
        int SkillID;
        public int Damage;
        public bool Done = false;
        public bool IsCasting = true;
        public bool IsDelayed = false;
        public float CastTime = 200; //time before move comes out 
        public float DelayTime = 200; //time user is stuck after casting
        Sprite Projectile;
        public float ProjectileSpeed = 5;
        private float _updateCounter;

        public Skill(Battler user, int skillID)
        {
            User = user;
            SkillID = skillID;
            UseSkill4();
        }

        //Larvuzz Basic Attack
        public void UseSkill4()
        {
            Projectile = new Sprite("Graphics/SkillAnimations/projectile4");
            Projectile.SetPosition(User.BattlerSprite.SpecterSprite.Position);
            User.BattlerSprite.ChangeState(CCSpecterState.State.AttackFar);
            User.BattlerSprite.SpecterSprite.TimeToUpdate = CastTime/User.BattlerSprite.SpecterSprite.FramesCount;
            User.BattlerSprite.SpecterSprite.PlayAndStop();
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
                User.BattlerSprite.SpecterSprite.ReverseAndStop();
                User.BattlerSprite.SpecterSprite.TimeToUpdate = DelayTime / User.BattlerSprite.SpecterSprite.FramesCount;
                User.BattlerSprite.SpecterSprite.Start();

            }
            else if (_updateCounter >= DelayTime && !IsCasting && IsDelayed) //Delay
            {
                _updateCounter = 0;
                User.IsAttacking = false;
                IsDelayed = false;
                User.BattlerSprite.ChangeState(CCSpecterState.State.Stand);
                User.BattlerSprite.SpecterSprite.Start();
            }
            else if (!IsCasting)
            {
                Projectile.SetPosition(Projectile.X + 5, Projectile.Y);
                if (Projectile.X > 500)
                {
                    Done = true;
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            if (!IsCasting)
            {
                Projectile.Draw(gameTime);
            }
            
        }

    }
}
