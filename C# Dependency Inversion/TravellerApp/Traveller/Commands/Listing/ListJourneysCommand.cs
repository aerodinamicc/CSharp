using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListJourneysCommand : ICommand
    {
        private readonly IDataCollections database;

        public ListJourneysCommand(IDataCollections database)
        {
            this.database = database ?? throw new ArgumentNullException("ListJourneysCommand database");
        }

        public string Execute(IList<string> parameters)
        {
            var journeys = database.Journeys;

            if (journeys.Count == 0)
            {
                return "There are no registered journeys.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, journeys);
        }
    }
}
