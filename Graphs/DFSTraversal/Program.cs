using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited = new HashSet<string>();

        public static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>
            {
                {"munich", new List<string> {"neufahrn", "eching", "freising", "laim"} },
                {"neufahrn", new List<string> {"eching", "erding", "moosach"} },
                {"freising", new List<string> {"neufahrn", "erding", "moosach"} },
                {"moosach", new List<string> {"munich"} },
                {"laim", new List<string> {"feldmoching", "munich", "schwabing"} },
                {"eching", new List<string> {"munich", "neufahrn"} },
                {"erding", new List<string> {"freising", "neufahrn"} },
                {"schwabing", new List<string> {"laim", "feldmoching"} },
                {"feldmoching", new List<string> {"munich", "laim", "schwabing"} },
            };

            DFS("neufahrn");
            Console.ReadKey();
        }

        public static void DFS(string node)
        {
            var nodes = new Stack<string>();
            nodes.Push(node);
            visited.Add(node);

            while (nodes.Count != 0)
            {
                string currentNode = nodes.Pop();
                Console.WriteLine(currentNode);

                for (int i = 0; i < graph[currentNode].Count; i++)
                {
                    if (!visited.Contains(graph[currentNode][i]))
                    {
                        nodes.Push(graph[currentNode][i]);
                        visited.Add(graph[currentNode][i]);
                    }
                }
            }
        }
    }


}
