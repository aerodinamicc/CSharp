using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden
{
    class Garden
    {
        static void Main()
        {
            string tomS = Console.ReadLine();
            double tomatoS = double.Parse(tomS);
            string tomA = Console.ReadLine();
            double tomatoA = double.Parse(tomA);
            string cucS = Console.ReadLine();
            double cucumS = double.Parse(cucS);
            string cucA = Console.ReadLine();
            double cucumA = double.Parse(cucA);
            string potS = Console.ReadLine();
            double potatoS = double.Parse(potS);
            string potA = Console.ReadLine();
            double potatoA = double.Parse(potA);
            string carS = Console.ReadLine();
            double carrotsS = double.Parse(carS);
            string carA = Console.ReadLine();
            double carrotsA = double.Parse(carA);
            string cabS = Console.ReadLine();
            double cabbageS = double.Parse(cabS);
            string cabA = Console.ReadLine();
            double cabbageA = double.Parse(cabA);
            string beaS = Console.ReadLine();
            double beansS = double.Parse(beaS);


            double areaTaken = (double)tomatoA + cucumA + potatoA + carrotsA + cabbageA;
            double price = (double)(tomatoS * 0.5) + (cucumS * 0.4) + (potatoS * 0.25) + (carrotsS * 0.6) + (cabbageS * 0.3) + (beansS * 0.4);
            Console.WriteLine("Total costs: {0:f2}", price);
            if (areaTaken == 250)
            {
                Console.WriteLine("No area for beans");
            }
            else if (areaTaken > 250)
            {
                Console.WriteLine("Insufficient area");
            }
            else if (areaTaken < 250)
            {
                Console.WriteLine("Beans area: {0:0}", 250 - areaTaken);
            }

        }
    }
}
