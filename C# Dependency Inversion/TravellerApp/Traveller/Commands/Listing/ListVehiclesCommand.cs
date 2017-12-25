using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListVehiclesCommand : ICommand
    {
        private readonly IDataCollections database;

        public ListVehiclesCommand(IDataCollections database)
        {
            this.database = database ?? throw new ArgumentNullException("ListVehiclesCommand database");
        }

        public string Execute(IList<string> parameters)
        {
            var vehicles = database.Vehicles;

            if (vehicles.Count == 0)
            {
                return "There are no registered vehicles.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, vehicles);
        }
    }
}
