using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using OlympicGames.Core.Commands.Abstracts;
using System;
using System.Text;
using OlympicGames.Olympics.Models;
using OlympicGames.Olympics.Enums;
using System.Linq;

public class CreateSprinterCommand: Command
    {
        // Consider using the dictionary
        private readonly IDictionary<string, double> records;
        private IOlympian sprinter;

        public CreateSprinterCommand(IList<string> commandLine)
            : base(commandLine)
        {

        if (commandLine.Count < 3)
        {
            throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
        }

        commandLine.ValidateIfNull();

        this.records = new Dictionary<string, double>();
        this.records = commandLine.Skip(3).Select(part =>
            part.Split('/')).
            ToDictionary(split => split[0],
            split => double.Parse(split[1]));

        this.sprinter = base.Factory.CreateSprinter(commandLine[0],
            commandLine[1],
            commandLine[2],
            records);
        base.Committee.Olympians.Add(this.sprinter);
        }

        public override string Execute()
        {
            return $"Created Sprinter\n" + 
                   sprinter.ToString();
        }
    }

