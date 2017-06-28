using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireInTheMatrix
{
    class Fire
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char blank = '.';
            char fire = '#';
            char top = '-';
            char leftTorch = '\\';
            char rightTorch = '/';


            //Upper part
            for (int i = 0; i < size/2; i++)
            {
                Console.Write(new string(blank, size / 2 - 1 - i));
                Console.Write(new string(fire, 1));
                Console.Write(new string(blank, i*2));
                Console.Write(new string(fire, 1));
                Console.WriteLine(new string(blank, size / 2 - 1 - i));
            }

            //Lower part of the fire
            int shift = size - 2;
            for (int i = 0; i < size / 4; i++)
            {
                Console.Write(new string(blank, i));
                Console.Write(new string(fire, 1));
                Console.Write(new string(blank, shift - 2 * i));
                Console.Write(new string(fire, 1));
                Console.WriteLine(new string(blank, i));
            }

            //Torch

            Console.WriteLine(new string(top, size));

            for (int i = 0; i < size / 2; i++)
            {
                Console.Write(new string(blank, i));
                Console.Write(new string(leftTorch, size / 2 - i));
                Console.Write(new string(rightTorch, size / 2 - i));
                Console.WriteLine(new string(blank, i));
            }
        }
    }
}
