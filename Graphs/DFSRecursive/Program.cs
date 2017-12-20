using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSRecursive
{
    public class Program
    {
        private static readonly List<List<int>> graph = new List<List<int>>()
        {
                        new List<int>() { 3, 6 }, // successors of node 0
                        new List<int>() { 2, 3, 4, 5, 6 }, // successors of node 1
                        new List<int>() { 1, 4, 5 }, // etc.
                        new List<int>() { 0, 1, 5 },
                        new List<int>() { 1, 2, 6 },
                        new List<int>() { 1, 2, 3 },
                        new List<int>() { 0, 1, 4 }
        };

        private static HashSet<int> visited = new HashSet<int>();

        public static void Main(string[] args)
        {
            DFS(4);
            Console.ReadKey();
        }

        public static void DFS(int num)
        {
            if (!visited.Contains(num))
            {
                visited.Add(num);
                Console.WriteLine(num);

                for (int i = 0; i < graph[num].Count; i++)
                {
                    DFS(graph[num][i]);
                }
            }
        }
    }
}
