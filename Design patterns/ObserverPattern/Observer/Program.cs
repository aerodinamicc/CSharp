using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observer.ConcreteObserver;
using Observer.ConcreteSubject;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var fan = new Fan();

            var eminem = new Eminem();
            eminem.AddFollower(fan);
            eminem.Notify("I am out on a new tour!");
            Console.ReadKey();
        }
    }
}
