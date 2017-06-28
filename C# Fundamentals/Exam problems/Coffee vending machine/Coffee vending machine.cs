using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_vending_machine
{
    class Coffee_vending_machine
    {
        static void Main()
        {
            double five = double.Parse(Console.ReadLine());
            double ten = double.Parse(Console.ReadLine());
            double twenty = double.Parse(Console.ReadLine());
            double fifty = double.Parse(Console.ReadLine());
            double lev = double.Parse(Console.ReadLine());

            double available = five * 0.05 + ten * 0.1 + twenty * 0.2 + fifty * 0.5 + lev * 1;
            double paid = double.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());

            if (paid > price)
            {
                double change = paid - price;
                if (available >= change)
                {
                    Console.WriteLine("Yes {0:f2}", available - change);
                }
                else
                {
                    Console.WriteLine("No {0:f2}", change - available);
                }
            }
            else
            {
                Console.WriteLine("More {0:f2}", price - paid);
            }
        }
    }
}
