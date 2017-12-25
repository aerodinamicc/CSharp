using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;

namespace Traveller.Commands.Creating
{
    public class CreateAirplaneCommand : ICommand
    {
        private readonly IDataCollections database;
        private readonly ITravellerFactory factory;

        public CreateAirplaneCommand(IDataCollections database, ITravellerFactory factory)
        {
            this.database = database ?? throw new ArgumentNullException("CreatePlaneCommand database");
            this.factory = factory ?? throw new ArgumentNullException("CreatePlaneCommand factory");
        }

        public string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            bool hasFreeFood;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                hasFreeFood = bool.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateAirplane command parameters.");
            }

            var airplane = factory.CreateAirplane(passengerCapacity, pricePerKilometer, hasFreeFood);
            this.database.Vehicles.Add(airplane);

            return $"Vehicle with ID {this.database.Vehicles.Count - 1} was created.";
        }
    }
}
