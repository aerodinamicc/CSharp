using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube
{
    class Cube
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char side = ':';
            char top = '/';
            char right = 'X';
            char blank = ' ';

            Console.Write(new string(blank, size - 1));
            Console.WriteLine(new string(side, size));
            
            for (int i = 0; i < size-2; i++)
            {
                Console.Write(new string(blank, size - 2 - i));
                Console.Write(new string(side, 1));
                Console.Write(new string(top, size-2));
                Console.Write(new string(side, 1));
                Console.Write(new string(right, i));
                Console.WriteLine(new string(side, 1));
            }
            Console.Write(new string(side, size));
            Console.Write(new string(right, size - 2));
            Console.WriteLine(new string(side, 1));

            for (int i = 0; i < size - 2; i++)
            {
                Console.Write(new string(side, 1));
                Console.Write(new string(blank, size - 2));
                Console.Write(new string(side, 1));
                Console.Write(new string(right, size - 3 - i));
                Console.WriteLine(new string(side, 1));
            }

            Console.Write(new string(side, size));
            Console.WriteLine(new string(blank, size - 1));

        }
    }
}
