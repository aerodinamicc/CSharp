using System;
using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using OlympicGames.Olympics.Models;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Providers;
using OlympicGames.Olympics.Enums;

namespace OlympicGames.Core.Commands
{
    public class CreateBoxerCommand : Command
    {
        private readonly IOlympian boxer;

        public CreateBoxerCommand(IList<string> commandLine)
            : base(commandLine)
        {
            if (commandLine.Count < 6)
            {
                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            }

            int wins = 0;
            int losses = 0;
            if (int.TryParse(commandLine[4], out wins) &&
            int.TryParse(commandLine[5], out losses))
            {
                this.boxer = base.Factory.CreateBoxer(commandLine[0],
                commandLine[1],
                commandLine[2],
                commandLine[3],
                int.Parse(commandLine[4]),
                int.Parse(commandLine[5]));
                base.Committee.Olympians.Add(boxer);
            }
            else
            {
                throw new ArgumentException(GlobalConstants.WinsLossesMustBeNumbers);
            }

            
        }

        public override string Execute()
        {
            //if in Boxer class it would also appear when
            //printing the Dictionary which is something unwanted
            return $"Created Boxer\n" + 
                   boxer.ToString();
        }
    }
}
