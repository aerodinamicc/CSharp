using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoSort_DigitOrderProblem_Matrix
{
    public class Program
    {
        private static int[,] adjMatrix = new int[10, 10];
        private static HashSet<int> visited = new HashSet<int>();
        private static HashSet<int> digits = new HashSet<int>();
        private static List<int> result = new List<int>();

        public static void PrintMatrix()
        {
            for (int i = 0; i < adjMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjMatrix.GetLength(1); j++)
                {
                    Console.Write(adjMatrix[i,j] + " "); 
                }
                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            ReadInData(lines);
            PrintMatrix();
            while (digits.Count != 0)
            {
                TopoSort(digits.Min());
            }
            Console.WriteLine(string.Join("", result));
            Console.ReadKey();
        }

        public static void ReadInData(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                string[] line = Console.ReadLine().Split(' ').ToArray();

                int column = 0; //leading
                int row = 0; //trailing number

                if (line[2] == "before")
                {
                    column = int.Parse(line[0]);
                    row = int.Parse(line[3]);
                }
                else if (line[2] == "after")
                {
                    column = int.Parse(line[3]);
                    row = int.Parse(line[0]);
                }

                adjMatrix[row, column] = 1;
                digits.Add(row);
                digits.Add(column);
            }
        }

        public static void TopoSort(int digit)
        {
            List<int> dependencies = new List<int>();

            for (int i = 0; i < adjMatrix.GetLength(1); i++)
            {
                if (adjMatrix[digit,i] == 1)
                {
                    dependencies.Add(i);
                }
            }

            visited.Add(digit);

            if (dependencies.Count == 0)
            {
                result.Add(digit);
                digits.Remove(digit);
            }
            else
            {
                foreach (int number in dependencies)
                {
                    if (!visited.Contains(number))
                    {
                        TopoSort(number);
                    }

                    adjMatrix[digit, number] = 0;
                }
            }
        }

    }
}
