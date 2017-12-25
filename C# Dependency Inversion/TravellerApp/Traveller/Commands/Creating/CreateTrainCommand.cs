using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;

namespace Traveller.Commands.Creating
{
    public class CreateTrainCommand : ICommand
    {
        private readonly IDataCollections database;
        private readonly ITravellerFactory factory;

        public CreateTrainCommand(IDataCollections database, ITravellerFactory factory)
        {
            this.database = database ?? throw new ArgumentNullException("CreateTrainCommand database");
            this.factory = factory ?? throw new ArgumentNullException("CreateTrainCommand factory");
        }

        public string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            int cartsCount;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                cartsCount = int.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTrain command parameters.");
            }

            var train = factory.CreateTrain(passengerCapacity, pricePerKilometer, cartsCount);
            this.database.Vehicles.Add(train);

            return $"Vehicle with ID {this.database.Vehicles.Count - 1} was created.";
        }
    }
}
