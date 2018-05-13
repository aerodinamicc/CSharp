using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBankEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var piggyBank = new PiggyBank();

            while (line != "exit")
            {
                var update = decimal.Parse(line);
                piggyBank.UpdateBalance(update);

                line = Console.ReadLine();
            }
        }
    }
}
