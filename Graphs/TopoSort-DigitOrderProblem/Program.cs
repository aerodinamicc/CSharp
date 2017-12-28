using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoSort_DigitOrderProblem
{
    public class Program
    {
        //dependencies dictionary contains trailngNumbers as keys and their leadingNumbers as values
        private static Dictionary<int, List<int>> dependencies = new Dictionary<int, List<int>>();
        private static bool isThereAZero;
        private static Queue<int> result = new Queue<int>();

        public static void ReadInData(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                string[] line = Console.ReadLine().Split(' ').ToArray();

                int leading = 0;
                int trailing = 0;

                if (line[2] == "before")
                {
                    leading = int.Parse(line[0]);
                    trailing = int.Parse(line[3]);
                }
                else if (line[2] == "after")
                {
                    leading = int.Parse(line[3]);
                    trailing = int.Parse(line[0]);
                }

                if (dependencies.ContainsKey(trailing) && dependencies[trailing].Contains(leading))
                {
                    continue;
                }
                else if (dependencies.ContainsKey(trailing))
                {
                    dependencies[trailing].Add(leading);
                }
                else
                {
                    List<int> leadingNum = new List<int>() { leading };
                    dependencies.Add(trailing, leadingNum);
                }

                //adds the leading num to the dictionary too
                if (!dependencies.ContainsKey(leading))
                {
                    List<int> list = new List<int>();
                    dependencies.Add(leading, list);
                }

                //isThereAZero
                if (!isThereAZero && (leading == 0 || trailing == 0))
                {
                    isThereAZero = true;
                }
            }
        }

        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            ReadInData(lines);

            while (dependencies.Count != 0)
            {
                int minDigit = dependencies.Keys.Min();
                TopoSort(minDigit);
            }

            Console.WriteLine(ShowResult());
            Console.ReadKey();

        }

        public static void TopoSort(int minDigit)
        {
            if (!isThereAZero && dependencies.ContainsKey(minDigit))
            {
                if (dependencies[minDigit].Count == 0)
                {
                    result.Enqueue(minDigit);
                    dependencies.Remove(minDigit);
                }
                else
                {
                    foreach (int digit in dependencies[minDigit])
                    {
                        if (dependencies.ContainsKey(digit))
                        {
                            TopoSort(digit);
                        }
                    }
                    
                    //visited[minDigit] = true; //marking
                    dependencies[minDigit].Clear();
                }
            }
        }

        public static string ShowResult()
        {
            StringBuilder output = new StringBuilder();
            int iterations = result.Count;
            for (int i = 0; i < iterations; i++)
            {
                output.Append(result.Dequeue());
            }

            return output.ToString();
        }
    }
}
