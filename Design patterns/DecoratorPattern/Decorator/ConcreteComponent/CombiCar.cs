using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Component;

namespace Decorator.ConcreteComponent
{
    public class CombiCar : ICar
    {
        public CombiCar()
        {
            Description = "Combi car.";
        }

        public string Description { get; set; }
        public string GetDescription() => Description;

        public double GetPrice() => 5000;
    }
}
