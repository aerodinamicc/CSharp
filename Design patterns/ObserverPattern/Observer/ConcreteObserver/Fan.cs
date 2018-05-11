using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observer.Observer;
using Observer.Subject;

namespace Observer.ConcreteObserver
{
    public class Fan : IFan
    {
        public void Update(ICelebrity celebrity)
        {
            Console.WriteLine($"Fan notified. {celebrity.FullName} tweeted {celebrity.Tweet}");
        }
    }
}
