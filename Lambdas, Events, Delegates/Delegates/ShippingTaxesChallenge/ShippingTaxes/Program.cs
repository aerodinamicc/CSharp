using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShippingTaxes
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Specify tax zone:");
            var taxZone = Console.ReadLine();

            while (taxZone != "exit")
            {
                var destination = ShippingZones.GetDestination(taxZone);
                if (destination == null)
                {
                    Console.WriteLine("Unknown zone has been specified!");
                }
                else
                {
                    Console.WriteLine("Specify article's price:");
                    var price = decimal.Parse(Console.ReadLine());
                    CalcTaxes calcFees = destination.CalcFee;
                    Console.WriteLine($"The price would be {calcFees(price, destination.IsHighRisk())}.");
                }

                Console.WriteLine("Specify tax zone:");
                taxZone = Console.ReadLine();
            }
        }
    }
}
