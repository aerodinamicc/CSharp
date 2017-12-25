using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListTicketsCommand : ICommand
    {
        private readonly IDataCollections database;

        public ListTicketsCommand(IDataCollections database)
        {
            this.database = database ?? throw new ArgumentNullException("ListTicketsCommand database");
        }

        public string Execute(IList<string> parameters)
        {
            var tickets = database.Tickets;

            if (tickets.Count == 0)
            {
                return "There are no registered tickets.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, tickets);
        }
    }
}
