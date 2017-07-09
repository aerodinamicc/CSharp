using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrenheitToCelsius
{
    class FahrenheitToCelsius
    {
        static void ToCelsius(double temp)
        {
            double result = (temp - 32) * 5 / 9;
            Console.WriteLine("{0:f2}", result);
            if (result > 37)
            {
                Console.WriteLine("You are ill!");
            }
            
        }
        static void Main()
        {
            double fahr = double.Parse(Console.ReadLine());
            ToCelsius(fahr);

        }

    }
}
