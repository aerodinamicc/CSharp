using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpresions;
using System.Threading.Tasks;

namespace Random
{
    class Random
    {
        static void Main()
        {
            Regex regex = new Regex(@"\d+");
            Match match = regex.Match("Dot 55 Perls");
            if (match.Success)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
