using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;

namespace Traveller.Commands.Creating
{
    public class CreateBusCommand : ICommand
    {
        private readonly IDataCollections database;
        private readonly ITravellerFactory factory;

        public CreateBusCommand(IDataCollections database, ITravellerFactory factory)
        {
            this.database = database?? throw new ArgumentNullException("createBusCommand database");
            this.factory = factory ?? throw new ArgumentNullException("createBusCommand factory"); 
        }

        public string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBus command parameters.");
            }

            var bus = factory.CreateBus(passengerCapacity, pricePerKilometer);
            this.database.Vehicles.Add(bus);

            return $"Vehicle with ID {this.database.Vehicles.Count - 1} was created.";
        }
    }
}
