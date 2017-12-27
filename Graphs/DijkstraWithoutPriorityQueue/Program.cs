using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraWithoutPriorityQueue
{
    public class Program
    {
        private static List<int> distance = new List<int>();
        private static List<int> previousNode = new List<int>();
        private static HashSet<int> setOfNodes = new HashSet<int>();
        
        public static void Dijkstra(int[,] graph, int source)
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                distance.Add(int.MaxValue);
                previousNode.Add(0);
                setOfNodes.Add(i);
            }

            distance[source] = 0;

            while(setOfNodes.Count != 0)
            {
                int minNode = int.MaxValue;

                foreach (var node in setOfNodes)
                {
                    if (distance[node] < minNode)
                    {
                        minNode = node;
                    }
                }

                setOfNodes.Remove(minNode);
                
                if (minNode == int.MaxValue)
                {
                    minNode = setOfNodes.First();
                }

                for (int i = 0; i < graph.GetLength(0) ; i++)
                {
                    if (graph[minNode,i] > 0)
                    {
                        int newDistanceToNode = distance[minNode] + graph[minNode, i];
                        if (distance[i] > newDistanceToNode)
                        {
                            distance[i] = newDistanceToNode;
                            previousNode[i] = minNode;
                        }
                    }
                }
            }

        }

        public static List<int> RecreatePath(int destination, int source)
        {
            List<int> steps = new List<int>();
            steps.Add(destination + 1);

            int step = previousNode[destination];

            while (step != source)
            {
                steps.Add(step + 1);
                step = previousNode[step];
            }

            steps.Add(source + 1);
            steps.Reverse();

            return steps;
        }

        public static void Main(string[] args)
        {
            int[,] graph = new int[,]
            {
                { 0, 7, 5, 0, 0, 0, 0, 0, 0, 0 },
                { 7, 0, 23, 0, 0, 6, 0, 0, 0, 0 },
                { 5, 23, 0, 40, 15, 0, 0, 0, 0, 0 },
                { 0, 0, 40, 0, 0, 0, 0, 17, 31, 50 },
                { 0, 0, 15, 0, 0, 13, 5, 0, 0, 0 },
                { 0, 6, 0, 0, 13, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 5, 0, 0, 4, 0, 0 },
                { 0, 0, 0, 17, 0, 0, 4, 0, 0, 0 },
                { 0, 0, 0, 31, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 50, 0, 0, 0, 0, 0, 0 }
            };

            Console.WriteLine("Departure node (1-10):");
            int source = int.Parse(Console.ReadLine()) - 1;

            Dijkstra(graph, source);
                        
            Console.WriteLine("Destination node (1-10):");
            int destination = int.Parse(Console.ReadLine()) - 1;

            string path = string.Join(" ", RecreatePath(destination, source));

            Console.WriteLine("The shortest way to go goes through: {0}, and it will take you {1}",
                path, distance[destination]);
            Console.ReadKey();
        }
    }
}
