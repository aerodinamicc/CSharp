using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Eggcelent
{
    class Eggcelent
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char blank = '.';
            char side = '*';
            char center = '@';

            Console.Write(new string(blank, size + 1));
            Console.Write(new string(side, size - 1));
            Console.WriteLine(new string(blank, size + 1));

            int temp = size;

            if(size > 2)
            {
                for (int i = 0; i < size/2; i++)
                {
                    Console.Write(new string(blank, temp - 1));
                    Console.Write(new string(side, 1));
                    Console.Write(new string(blank, temp + 1));
                    Console.Write(new string(side, 1));
                    Console.WriteLine(new string(blank, temp-1));
                    temp += 2;
                }
            }



        }
    }
}
