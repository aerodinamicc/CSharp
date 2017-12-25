using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;

namespace Traveller.Core.Providers
{
    public class CommandParser : IParser
    {
        private readonly ICommandFactory commandFactory;

        public CommandParser(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory ?? throw new ArgumentNullException("CommandParser commandFactory");
        }

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split()[0];

            if (commandName != "createairplane" && 
                commandName != "createbus" &&
                commandName != "createjourney" &&
                commandName != "createticket" &&
                commandName != "createtrain" &&
                commandName != "listjourneys" &&
                commandName != "listtickets" &&
                commandName != "listvehicles")
            {
                throw new ArgumentException("Non-existant command");
            }

            return this.commandFactory.CreateCommand(commandName);
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split().Skip(1).ToList();
            if (commandParts.Count == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}
