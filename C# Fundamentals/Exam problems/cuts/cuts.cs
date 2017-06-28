using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cuts
{
    class cuts
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int numCopy = num;
            int[] folds = { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 };
            string[] sizes = { "A0", "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10" };

            string[] result = new string[10];
            for (int i = 0; i < 11; i++)
            {
                if (numCopy / folds[i] > 0)
                {
                    numCopy = numCopy - (folds[i] * (numCopy / folds[i]));

                }
                else
                {
                    Console.WriteLine(sizes[i]);
                }
              
            }
        }
    }
}
