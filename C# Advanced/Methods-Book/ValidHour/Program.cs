using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods_Book
{
    class Book
    {
        static bool ValidHour(int hour)
        {
            bool validity = (hour > -1) && (hour < 24);
            return validity;

        }
        static bool ValidMinutes(int minutes)
        {
            bool validity = (minutes > -1) && (minutes < 60);
            return validity;

        }
        static void PrintingTime(int hour, int minutes)
        {
            if (ValidHour(hour) && ValidMinutes(minutes))
            {
                Console.WriteLine("So you say it's {0}:{1} now?", hour, minutes);
            }
            else
            {
                Console.WriteLine("Invalid time!");
            }
        }
        static void Main()
        {
            Console.WriteLine("What' sthe time? PLease enter a valid hoir (0-23)");
            int hour = int.Parse(Console.ReadLine());
            Console.WriteLine("PLease enter a valid minutes (0-59)");
            int minutes = int.Parse(Console.ReadLine());
            PrintingTime(hour, minutes);
        }

    }
}
