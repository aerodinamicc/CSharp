using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Class1
    {
        static void Main()
        {
            string[] line = Console.ReadLine().Split(' ');
            int rowCount = int.Parse(line[0]);
            int colCount = int.Parse(line[1]);

            //reading in
            int[,] arr = new int[rowCount, colCount];
            for (int j = 0; j < rowCount; j++)
            {
                string[] temp = Console.ReadLine().Split(' ');
                int[] tempInt = Array.ConvertAll(temp, int.Parse);
                for (int i = 0; i < colCount; i++)
                {
                    arr[j, i] = tempInt[i];
                }
            }
            // summing up
            //int.MinValue is crucial especially when negative numbers are involved
            long max = int.MinValue;
            for (int row = 0; row < rowCount - 2; row++)
            {
                for (int col = 0; col < colCount - 2; col++)
                {
                    long sum = arr[row, col] + arr[row + 1, col] + arr[row + 2, col] +
                        arr[row, col + 1] + arr[row + 1, col + 1] + arr[row + 2, col + 1] +
                        arr[row, col + 2] + arr[row + 1, col + 2] + arr[row + 2, col + 2];
                    if (sum > max)
                    {
                        max = sum;
                    }
                }
            }
            Console.WriteLine(max);
        }
    }
}
