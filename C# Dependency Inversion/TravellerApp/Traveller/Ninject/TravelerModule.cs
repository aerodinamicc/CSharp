using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Contracts;
using Traveller.Commands.Creating;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Decorator;
using Traveller.Core.Factories;
using Traveller.Core.Providers;

namespace Traveller.Ninject
{
    class TravelerModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEngine>().To<Engine>().InSingletonScope().Named("engine");
            this.Bind<IEngine>().To<LoggingDecorator>().Named("logging")
                .WithConstructorArgument(this.Kernel.Get<IEngine>("engine"));
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IParser>().To<CommandParser>();
            this.Bind<ITravellerFactory>().To<TravellerFactory>().InSingletonScope();
            this.Bind<IDataCollections>().To<DataCollections>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>();

            //here are all the commands with relevant naming
            this.Bind<ICommand>().To<CreateAirplaneCommand>().Named("createairplane");
            this.Bind<ICommand>().To<CreateBusCommand>().Named("createbus");
            this.Bind<ICommand>().To<CreateJourneyCommand>().Named("createjourney");
            this.Bind<ICommand>().To<CreateTicketCommand>().Named("createticket");
            this.Bind<ICommand>().To<CreateTrainCommand>().Named("createtrain");
            this.Bind<ICommand>().To<ListJourneysCommand>().Named("listjourneys");
            this.Bind<ICommand>().To<ListTicketsCommand>().Named("listtickets");
            this.Bind<ICommand>().To<ListVehiclesCommand>().Named("listvehicles");

            


        }
    }
}
