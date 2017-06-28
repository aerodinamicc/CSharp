using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersianRugs
{
    class PersianRugs
    {
        static void Main()
        {
            // 55/100-points solution

            int width = int.Parse(Console.ReadLine());
            int inner = int.Parse(Console.ReadLine());

            char blank = ' ';
            char left = '\\';
            char right = '/';
            char dot = '.';
            char fill = '#';

            if (inner >= width - 1)
            {
                for (int i = 0; i < width; i++)
                {
                    Console.Write(new string(fill, i));
                    Console.Write(new string(left, 1));
                    Console.Write(new string(blank, (width * 2 - 1) - 2 * i));
                    Console.Write(new string(right, 1));
                    Console.WriteLine(new string(fill, i));

                }
                Console.Write(new string(fill, width));
                Console.Write(new string('X', 1));
                Console.WriteLine(new string(fill, width));

                int mid = 1;
                for (int i = width; i > 0; i--)
                {
                    Console.Write(new string(fill, i - 1));
                    Console.Write(new string(right, 1));
                    Console.Write(new string(blank, mid));
                    Console.Write(new string(left, 1));
                    Console.WriteLine(new string(fill, i - 1));
                    mid += 2;
                }
            }
        }
    }
}
