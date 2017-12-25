using System;

using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;

namespace OlympicGames.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandParser parser;
        private readonly ICommandProcessor commandProcessor;
        //private readonly IOlympicsFactory factory;
        //private readonly IOlympicCommittee commitee;

        private const string Delimiter = "####################";
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer,
            ICommandParser parser, ICommandProcessor processor)
        {
            this.writer = writer;
            this.reader = reader;
            this.parser = parser;
            this.commandProcessor = processor;
        }

        public void Run()
        {
            string commandLine = null;

            //IReader reader = new ConsoleReader(); That's a bad example since
            //when programming against abstractions we basically dont have to
            //see the newly created object
            while ((commandLine = reader.Read()) != "end")
            {
                try
                {
                    var command = this.parser.ParseCommand(commandLine);
                    if (command != null)
                    {
                        this.commandProcessor.Add(command);
                        this.commandProcessor.ProcessSingleCommand(command);
                        this.writer.Write(Delimiter);
                    }
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }

                    this.writer.Write(string.Format("ERROR: {0}", ex.Message));
                }
            }
        }

    }
}
