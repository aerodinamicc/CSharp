using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Component;
using Decorator.ConcreteDecorator;

namespace Decorator.ConcreteComponent
{
    public class SportsCar : ICar
    {
        public SportsCar()
        {
            Description = "Sports car.";
        }

        public string Description { get; set; }
        public string GetDescription() => Description;

        public double GetPrice() => 30000;
    }
}
