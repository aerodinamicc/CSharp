using Ninject;
using OlympicGames.Core;
using OlympicGames.Core.Contracts;
using OlympicGames.Ninject;

namespace OlympicGames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // Don not touch here (Magic Unicorns)
            IKernel kernel = new StandardKernel(new OmlympiansModule());
            IEngine engine = kernel.Get<IEngine>();
            engine.Run();
        }
    }
}
