using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSpace
{
    public class Program
    {
        private static Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        private static int[] times;
        private static int[] optimalTimes;

        public static void Main()
        {
            int tasks = int.Parse(Console.ReadLine());
            times = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            //reading in the dependancy data and setting our dictionary with descendants
            for (int i = 0; i < tasks; i++)
            {
                var parents = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

                if (parents[0] == 0)
                {
                    dict.Add(i, new List<int>());
                    continue;
                }

                parents = parents.Select(x => x - 1).ToList();  // -1 to make them zero-based
                dict.Add(i, new List<int>());
                dict[i].AddRange(parents);
            }
            optimalTimes = new int[tasks];
            for (int i = 0; i < optimalTimes.Length; i++)
            {
                optimalTimes[i] = CalculateMinTime(i);
            }

            Console.WriteLine(optimalTimes.Max());
        }

        public static int CalculateMinTime(int task)
        {
            if (optimalTimes[task] > 0) //if already computed
            {
                return optimalTimes[task];
            }

            if (dict[task].Count == 0) //if there are no dependancies
            {
                return times[task];
            }

            if (optimalTimes[task] < 0) //if a cyclic dependency is found
            {
                Console.WriteLine(-1);
                Environment.Exit(0);
            }
            optimalTimes[task] = -1;

            int maxDependencyTime = 0;

            foreach (int parent in dict[task])
            {
                int dependencyTime = CalculateMinTime(parent); //recursive, goes in depth
                maxDependencyTime = Math.Max(dependencyTime, maxDependencyTime);
            }

            optimalTimes[task] = times[task] + maxDependencyTime;
            return optimalTimes[task];
        }
    }
}
