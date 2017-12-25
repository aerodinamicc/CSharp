using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class AddAttackWhenSkip : Specialty
    {
        private int additionalAttack;

        public AddAttackWhenSkip(int attackPoints)
        {
            if (attackPoints < 1 || attackPoints > 10)
            {
                throw new ArgumentOutOfRangeException("Attack points should be between 1 and 10!");
            }

            this.additionalAttack = attackPoints;
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }

            skipCreature.PermanentAttack += this.additionalAttack;

        }

        public override string ToString()
        {
            string line = $"{base.ToString()}({this.additionalAttack})";
            return line;
        }

    }
}
