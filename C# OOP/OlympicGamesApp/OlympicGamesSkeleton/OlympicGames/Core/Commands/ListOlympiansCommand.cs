using System.Collections.Generic;
using System.Linq;
using System.Text;

using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Contracts;
using OlympicGames.Utils;
using System;

namespace OlympicGames.Core.Commands
{
    public class ListOlympiansCommand : Command, ICommand
    {
        private string key;
        private string order;

        public ListOlympiansCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
            this.key = "firstname";
            this.order = "asc";

            if (commandParameters.Count > 1 &&
                (commandParameters[1] == "asc" ||
                commandParameters[1] == "desc") &&
                (commandParameters[0] == "firstname" ||
                commandParameters[0] == "lastname" ||
                commandParameters[0] == "country"))
            {
                key = commandParameters[0];
                order = commandParameters[1];
            }
            else if (commandParameters.Count > 0 &&
                (commandParameters[0] == "firstname" ||
                commandParameters[0] == "lastname" ||
                commandParameters[0] == "country"))
            {
                key = commandParameters[0];
            }
        }

        // Use it. It works!
        public override string Execute()
        {
            if (base.Committee.Olympians.Count > 0)
            {
                var stringBuilder = new StringBuilder();

                var sorted = this.Committee.Olympians.ToList();

                stringBuilder.AppendLine(string.Format(GlobalConstants.SortingTitle, this.key, this.order));

                if (this.order.ToLower().Trim() == "desc")
                {
                    sorted = this.Committee.Olympians.OrderByDescending(x =>
                    {
                        return x.GetType().GetProperties().FirstOrDefault(y => y.Name.ToLower() == this.key.ToLower()).GetValue(x, null);
                    }).ToList();
                }
                else
                {
                    sorted = this.Committee.Olympians.OrderBy(x =>
                    {
                        return x.GetType().GetProperties().FirstOrDefault(y => y.Name.ToLower() == this.key.ToLower()).GetValue(x, null);
                    }).ToList();
                }

                foreach (var item in sorted)
                {
                    stringBuilder.AppendLine(item.ToString());
                }
                return stringBuilder.ToString();
            }
            else
            {
                return GlobalConstants.NoOlympiansAdded.ToString();
                
            }

            
        }
    }
}
