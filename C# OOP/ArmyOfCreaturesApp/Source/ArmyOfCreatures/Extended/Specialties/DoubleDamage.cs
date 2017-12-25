using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class DoubleDamage : Specialty
    {
        private int rounds;

        public DoubleDamage(int rounds)
        {
            if (rounds < 0 || rounds > 10)
            {
                throw new ArgumentOutOfRangeException("Should be between 1 and 10!");
            }

            this.rounds = rounds;
        }

        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender, decimal currentDamage)
        {
            if (rounds < 1)
            {
                return currentDamage;
            }
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attacker");
            }
            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            //Add class DoubleDamage. The DoubleDamage is a specialty that
            //doubles the current damage during battle

            this.rounds--;
            return currentDamage * 2;
        }


        public override string ToString()
        {
            string line = string.Format($"{base.ToString()}({this.rounds})");
            return line; 
        }

    }
}
