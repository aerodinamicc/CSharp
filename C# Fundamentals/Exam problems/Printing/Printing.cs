using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printing
{
    class Printing
    {
        static void Main()
        {
            double num = double.Parse(Console.ReadLine());
            double sheets = double.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());


            Console.WriteLine("{0:f3}", ((num * sheets) / 500) * price);



        }
    }
}
