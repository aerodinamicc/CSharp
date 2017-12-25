using ArmyOfCreatures.Logic.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Extended.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class CyclopsKing : Creature
    {
        public CyclopsKing():
            base(17, 13, 70, 18)
        {
            AddSpecialty(new AddAttackWhenSkip(3));
            AddSpecialty(new DoubleAttackWhenAttacking(4));
            AddSpecialty(new DoubleDamage(1));
        }
    }
}
