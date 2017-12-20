using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSwithQueue
{
    public class Program
    {
        private static bool[] visited = new bool[6];

        private static int[,] graph = new int[6, 6]
                        {
                            { 0, 1, 0, 0, 1, 0 },
                            { 1, 0, 1, 0, 0, 1 },
                            { 0, 0, 0, 1, 0, 0 },
                            { 0, 1, 0, 0, 0, 1 },
                            { 1, 0, 0, 1, 0, 1 },
                            { 1, 0, 1, 0, 1, 0 }
                        };
        public static void Main(string[] args)
        {
            BFS(3);
            Console.ReadKey();
        }

        public static void BFS(int node)
        {
            var nodes = new Queue<int>();
            nodes.Enqueue(node);
            visited[node] = true;
            while (nodes.Count != 0)
            {
                int currentNode = nodes.Dequeue();
                Console.WriteLine(currentNode);

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[currentNode, i] == 1 && !visited[i])
                    {
                        nodes.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }
    }
}
