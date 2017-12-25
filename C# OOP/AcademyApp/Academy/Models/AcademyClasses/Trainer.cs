using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.AcademyClasses 
{
    public class Trainer : ITrainer
    {
        private IList<string> technologies;
        private string username;

        public Trainer(string username, string technologiesList)
        {
            this.Username = username;
            technologies = new List<string>();
            technologies = technologiesList.Split(',').ToList();
        }

        public IList<string> Technologies
        {
            get
            {
                return this.technologies;
            }
            set
            {
                this.technologies = value;
            }
        }
        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if(!string.IsNullOrEmpty(value) && value.Length > 2 &&
                    value.Length < 17)
                {
                    this.username = value; //.ToLower()
                }
                else
                {
                    throw new ArgumentException(
                        "User's username should be between 3 and 16 symbols long!");
                }
            }
        }

        public override string ToString()
        {
            return $"* Trainer:\n" +
                   $" - Username: {this.username}\n" +
                   $" - Technologies: {string.Join("; ",this.technologies)}";
        }
    }
}
