using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondTrolls
{
    class DiamondTrolls
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char blank = '.';
            char diamond = '*';
 
            Console.Write(new string(blank, size/2 + 1));
            Console.Write(new string(diamond, size));
            Console.WriteLine(new string(blank, size/2 + 1));

            for (int i = 0; i < size/2; i++)
            {
                Console.Write(new string(blank, size/2 - i));
                Console.Write(new string(diamond, 1));
                Console.Write(new string(blank, size/2 + i));
                Console.Write(new string(diamond, 1));
                Console.Write(new string(blank, size / 2 + i));
                Console.Write(new string(diamond, 1));
                Console.WriteLine(new string(blank, size / 2 - i));
            }

            Console.WriteLine(new string(diamond, size*2 +1));

            for (int i = 0; i < size - 1; i++)
            {
                Console.Write(new string(blank, 1 + i));
                Console.Write(new string(diamond, 1));
                Console.Write(new string(blank, size- 2 - i));
                Console.Write(new string(diamond, 1));
                Console.Write(new string(blank, size -2 - i));
                Console.Write(new string(diamond, 1));
                Console.WriteLine(new string(blank, 1 + i));
            }
            Console.Write(new string(blank, size));
            Console.Write(new string(diamond, 1));
            Console.WriteLine(new string(blank, size));
        }
    }
}
