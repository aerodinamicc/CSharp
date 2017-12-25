using Ninject;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Decorator;
using Traveller.Ninject;

namespace Traveller
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            /*
createbus 10 0.7
createtrain 300 0.4 3
createairplane 250 1 true
createairplane 250 2.7 true
createtrain 80 0.4 3
listvehicles
createjourney Sofia vTurnovo 300 0
createjourney Sofia vTurnovo 3 0
createjourney vTurnovo Sofia 300 3
listjourneys
createticket 0 30
createticket 1 100
listtickets
exit
*/
            IKernel kernel = new StandardKernel(new TravelerModule());
            var decorator = kernel.Get<IEngine>("logging");
            decorator.Start();

        }
    }
}
