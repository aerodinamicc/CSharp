using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutantSquirrels
{
    class MutantSquirrels
    {
        static void Main()
        {
            double T = double.Parse(Console.ReadLine());
            double B = double.Parse(Console.ReadLine());
            double S = double.Parse(Console.ReadLine());
            double N = double.Parse(Console.ReadLine());

            double result = T * B * S * N;

            if (result % 2 == 0)
            {
                result *= 376439;
            }
            else
            {
                result /= 7;
            }
            Console.WriteLine("{0:f3}", result);
        }
    }
}
