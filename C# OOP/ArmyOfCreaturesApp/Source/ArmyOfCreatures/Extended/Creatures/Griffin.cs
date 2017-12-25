using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class Griffin : Creature
    {
        public Griffin():
            base(8, 8, 25, 4.5m)
        {
            AddSpecialty(new DoubleDefenseWhenDefending(5));
            AddSpecialty(new AddDefenseWhenSkip(3));
            AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
