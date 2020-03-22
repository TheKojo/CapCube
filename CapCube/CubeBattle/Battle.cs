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
        Field Field = new Field();

        //battlers[0] = player active specter
        //battlers[1+] = opponent active specter
        public List<Battler> ActiveBattlers = new List<Battler>();

        //Wild Battle
        public Battle(List<Specter> opponents)
        {
            ActiveBattlers.Add(new Battler(GameUtils.Player.Party[0], 0));
            for (int i = 0; i<opponents.Count; i++)
            {
                ActiveBattlers.Add(new Battler(opponents[i], 1 + i));
            }
        }

        //Trainer Battle
        public Battle(Trainer opponent)
        {
            Opponent = opponent;
            ActiveBattlers[0] = new Battler(GameUtils.Player.Party[0], 0);
            ActiveBattlers[1] = new Battler(opponent.Party[0], 1);
        }
    }
}
