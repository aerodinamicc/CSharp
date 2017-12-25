using System;
using System.Collections.Generic;
using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System.Text;
using Academy.Models.Contracts;

namespace Academy.Commands.Listing
{
    public class ListUsersCommand : ICommand
    {
        // TODO: Implement this
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListUsersCommand(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            StringBuilder builder = new StringBuilder();

            if (this.engine.Trainers.Count > 0)
            {
                foreach (var trainer in this.engine.Trainers)
                {
                    builder.AppendLine(trainer.ToString());
                }

            }

            if (engine.Students.Count > 0)
            {
                foreach (var student in engine.Students)
                {
                    builder.AppendLine(student.ToString());
                }
            }


            if (builder.ToString() == "")
            {
                return $"There are no users in this season!";
            }

            return builder.ToString().TrimEnd();
        }
    }
}
