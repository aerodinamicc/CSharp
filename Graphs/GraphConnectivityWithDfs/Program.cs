using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSRecursive
{
    public class Program
    {
        private static readonly Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>
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

        private static HashSet<string> visited = new HashSet<string>();

        public static void Main(string[] args)
        {
            var countOfComponents = 0;
            foreach (var node in graph)
            {
                if (!visited.Contains(node.Key))
                {
                    DFS(node.Key);
                    countOfComponents++;
                }
            }
            Console.WriteLine("The graph has the following number of components: " + countOfComponents);
            Console.ReadKey();
        }

        public static void DFS(string place)
        {
            if (!visited.Contains(place))
            {
                visited.Add(place);

                for (int i = 0; i < graph[place].Count; i++)
                {
                    DFS(graph[place][i]);
                }
            }
        }
    }
}
