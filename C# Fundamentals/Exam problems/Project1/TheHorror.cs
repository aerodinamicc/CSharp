using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class TheHorror
    {
        static void Main()
        {
            string line = Console.ReadLine();
            int i = 0;
            string message = "Fell off the dancefloor at {0}";
            while(i >= 0 && i < line.Length)
            {
                char sym = line[i];
                int num = sym - '0';
                if (sym == '^') { message = "Jump, Jump, DJ Tomekk kommt at {0}!"; break; }
                else if (num == 0) { message = "Too drung to go after {0}!"; break; }
                else if (num % 2 == 0) { i += num; }
                else if (num % 2 == 1) { i -= num; }

            }
            Console.WriteLine(message, i);
        }
    }
}
