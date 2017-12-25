using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Models;
using Traveller.Models.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateTicketCommand : ICommand
    {
        private readonly IDataCollections database;
        private readonly ITravellerFactory factory;

        public CreateTicketCommand(IDataCollections database, ITravellerFactory factory)
        {
            this.database = database ?? throw new ArgumentNullException("CreateTicketCommand database");
            this.factory = factory ?? throw new ArgumentNullException("CreateTicketCommand factory");
        }

        public string Execute(IList<string> parameters)
        {
            IJourney journey;
            decimal administrativeCosts;

            try
            {
                journey = this.database.Journeys[int.Parse(parameters[0])];
                administrativeCosts = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTicket command parameters.");
            }

            var ticket = factory.CreateTicket(journey, administrativeCosts);
            this.database.Tickets.Add(ticket);

            return $"Ticket with ID {this.database.Tickets.Count - 1} was created.";
        }
    }
}
