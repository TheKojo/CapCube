using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCube
{
    class Specter
    {
        public int Species;

        public CCElement.Element Element1;
        public CCElement.Element Element2;

        public int Level;
        public int TotalHP;
        public int HP;
        public int TotalPP;
        public int PP;
        public int Attack;
        public int Defense;
        public int SpAtk;
        public int SpDef;
        public int Speed;

        public int Gender;
        public string Nickname;

        public Specter(int species, int level)
        {
            Species = species;
            Level = level;

            CapCubeData.Specter specterData = GameUtils.GetSpecter(species);
            Element1 = (CCElement.Element) specterData.Element1ID;
            Element2 = (CCElement.Element) specterData.Element2ID;

            TotalHP = CalcHP(specterData.HP);
            HP = TotalHP;
            TotalPP = CalcPP(specterData.HP);
            PP = TotalHP;
            Attack = CalcStat(specterData.Attack);
            Defense = CalcStat(specterData.Attack);
            SpAtk = CalcStat(specterData.SpAtk);
            SpDef = CalcStat(specterData.SpDef);
            Speed = CalcSpeed(specterData.Speed);

            //Damage = [move power %] * [attack or special attack] * [attack or special attack] / [target defense or special defense]   
        }

        private int CalcHP(int baseHP)
        {
            int hpVal = (baseHP * Level) / 5;
            return hpVal;
        }

        private int CalcPP(int basePP)
        {
            int ppVal = (basePP * Level) / 5;
            return ppVal;
        }

        private int CalcStat(int baseStat)
        {
            int statVal = (baseStat * Level) / 50;
            return statVal;
        }

        private int CalcSpeed(int baseStat)
        {
            int statVal = (int) (baseStat + Math.Sqrt(Level)*3) ; // /30
            return statVal;
        }

    }
}
