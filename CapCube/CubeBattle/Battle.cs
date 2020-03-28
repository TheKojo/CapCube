using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCube
{
    class Battle
    {
        Trainer Opponent;
        public Field Field = new Field();

        //battlers[0] = player active specter
        //battlers[1+] = opponent active specter
        public List<Battler> ActiveBattlers = new List<Battler>();

        //Wild Battle
        public Battle(List<Specter> opponents)
        {
            ActiveBattlers.Add(new Battler(this, GameUtils.Player.Party[0], 0));
            for (int i = 0; i<opponents.Count; i++)
            {
                ActiveBattlers.Add(new Battler(this, opponents[i], 1 + i));
            }
        }

        //Trainer Battle
        public Battle(Trainer opponent)
        {
            Opponent = opponent;
            ActiveBattlers[0] = new Battler(this, GameUtils.Player.Party[0], 0);
            ActiveBattlers[1] = new Battler(this, opponent.Party[0], 1);
        }

        public void AddSkill(Skill skill)
        {
            Field.ActiveSkills.Add(skill);
        }
    }
}
