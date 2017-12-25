using Ninject.Modules;
using OlympicGames.Core;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.Ninject
{
    public class OmlympiansModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<ICommandParser>().To<CommandParser>().
                InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().
                InSingletonScope();
        }
    }
}
