using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            StringBuilder output = new StringBuilder();

            char prev = ' ';
            char current = ' ';
            for (int i = 0; i < line.Length; i++)
            {
                current = line[i];
                if (current != prev)
                {
                    output.Append(line[i]);
                    prev = current;
                }
            }
            Console.WriteLine(output.ToString());
        }
    }
}
