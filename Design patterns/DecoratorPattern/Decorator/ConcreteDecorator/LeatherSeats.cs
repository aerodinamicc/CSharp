using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Component;
using Decorator.Decorator;

namespace Decorator.ConcreteDecorator
{
    public class LeatherSeats : CarDecorator
    {
        public LeatherSeats(ICar car) : base(car)
        {
            Description = "Leather seats.";
        }

        public override string GetDescription() => base.GetDescription() + " with leather seats.";

        public override double GetPrice() => base.GetPrice() + 2000;
    }
}
