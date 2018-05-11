using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Component;
using Decorator.ConcreteComponent;
using Decorator.ConcreteDecorator;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            ICar car = new SportsCar();
            car = new LeatherSeats(car);

            Console.WriteLine(car.GetDescription());
            Console.ReadKey();
        }
    }
}
