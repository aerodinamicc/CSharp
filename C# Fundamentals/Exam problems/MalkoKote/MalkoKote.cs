using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalkoKote
{
    class MalkoKote
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int ratio = ((size - 10) / 4) + 1;
            char sym = char.Parse(Console.ReadLine());
            char blank = ' ';

            Console.Write(new string(blank, 1));
            Console.Write(new string(sym, 1));
            Console.Write(new string(blank, ratio));
            Console.WriteLine(new string(sym, 1));

            for (int i = 0; i < ratio; i++)
            {
                Console.Write(new string(blank, 1));
                Console.WriteLine(new string(sym, 2 + ratio));
            }
            for (int i = 0; i < ratio; i++)
            {
                Console.Write(new string(blank, 2));
                Console.WriteLine(new string(sym, ratio));
            }
            for (int i = 0; i < ratio; i++)
            {
                Console.Write(new string(blank, 1));
                Console.WriteLine(new string(sym, 2 + ratio));
            }
            Console.Write(new string(blank, 1));
            Console.Write(new string(sym, 2 + ratio));
            Console.Write(new string(blank, 3));
            Console.WriteLine(new string(sym, ratio + 1));

            for (int i = 0; i < ratio +2; i++)
            {
                Console.Write(new string(sym, ratio + 4));
                Console.Write(new string(blank, 2));
                Console.WriteLine(new string(sym, 1));
            }

            Console.Write(new string(sym, ratio + 4));
            Console.Write(new string(blank, 1));
            Console.WriteLine(new string(sym, 2));

            Console.Write(new string(blank, 1));
            Console.WriteLine(new string(sym, ratio + 5));
        }
    }
}
