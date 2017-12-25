using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.AcademyClasses
{
    public class Lecture : ILecture
    {
        private string name;
        private DateTime date;
        private ITrainer trainer;
        private IList<ILectureResource> resources;

        public Lecture(string name, string date, ITrainer trainer)
        {
            this.Name = name;
            this.Date = DateTime.Parse(date);
            this.Trainer = trainer;
            this.Resources = new List<ILectureResource>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length > 4 && value.Length < 31)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException(
                        "Lecture's name should be between 5 and 30 symbols long!");
                }
            }
        }
        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }
        public ITrainer Trainer
        {
            get
            {
                return this.trainer;
            }
            set
            {
                this.trainer = value;
            }
        }

        public IList<ILectureResource> Resources
        {
            get
            {
                return this.resources;
            }
            set
            {
                this.resources = value;
            }
        }

        public override string ToString()
        {
            StringBuilder resourcesList = new StringBuilder();
            if (this.Resources.Count < 1)
            {
                resourcesList.Append("    * There are no resources in this lecture.");
            }
            else
            {
                foreach (var resource in this.Resources)
                {
                    resourcesList.Append(resource.ToString() + "\n");
                }
                resourcesList.Length -= 1;
            }
            return $"  * Lecture:\n" +
                   $"   - Name: {this.Name}\n" +
                   $"   - Date: {this.Date.ToString()}\n" +
                   $"   - Trainer username: {this.Trainer.Username.ToString()}\n" +
                   $"   - Resources:\n" +
                   $"{resourcesList}";
        }
    }
}
