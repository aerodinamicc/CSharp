using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iterator.Aggregate;
using Iterator.Iterator;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var nyt = new NewYorkTimes();
            var wp = new WashingtonPost();

            var nytIterator = nyt.CreateIterator();
            var wpIterator = wp.CreateIterator();

            Console.WriteLine("---NYTimes---");
            PrintReporters(nytIterator);
            Console.WriteLine("---WashingtonPost---");
            PrintReporters(wpIterator);
            Console.ReadKey();
        }

        private static void PrintReporters(IIterator iterator)
        {
            iterator.First();
            while (!iterator.IsDone())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}
