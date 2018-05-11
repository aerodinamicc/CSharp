using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Component;

namespace Decorator.Decorator
{
    public class CarDecorator : ICar
    {
        private ICar _car;

        public CarDecorator(ICar car)
        {
            _car = car;
        }

        public string Description { get; set; }

        public virtual string GetDescription() => _car.GetDescription();

        public virtual double GetPrice() => _car.GetPrice();
    }
}
