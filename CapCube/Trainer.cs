using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCube
{
    class Trainer
    {
        public string Name;
        public CCGender.Gender Gender;
        public List<Specter> Party = new List<Specter>(3);

        public Trainer(){
        }

        public Trainer(string name, CCGender.Gender gender)
        {
            Name = name;
            Gender = gender;
        }

        public void AddSpecter(Specter specter)
        {
            Party.Add(specter);
        }


    }
}
