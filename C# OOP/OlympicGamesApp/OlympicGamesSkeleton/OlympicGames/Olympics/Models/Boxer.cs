using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics.Enums;
using OlympicGames.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.Olympics.Models
{
    public class Boxer: Olympian, IBoxer
    {
        private BoxingCategory category;
        private int wins;
        private int losses;

        public Boxer(string firstName, string lastName, string country,
            string category, int wins, int losses)
            : base(firstName, lastName, country)
        {
            BoxingCategory categoryType;
            Enum.TryParse(category, true, out categoryType);
            this.Category = categoryType; //StringToBoxCategory(category);
            this.Wins = wins;
            this.losses = losses;
        }

        public BoxingCategory Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                this.category = value;
            }
        }

        public int Wins
        {
            get
            {
                return this.wins;
            }
            private set
            {
                Validator.ValidateIfNull(value);
                Validator.ValidateMinAndMaxNumber(value, 0, 100,
                    "Wins must be between 0 and 100!");
                this.wins = value;
            }
        }

        public int Losses
        {
            get
            {
                return this.losses;
            }
            set
            {
                Validator.ValidateIfNull(GlobalConstants.WinsLossesMustBeNumbers);
                Validator.ValidateMinAndMaxNumber(value, 0, 100,
                    "Losses must be between 0 and 100!");
                this.losses = value;
            }
        }

        public override string ToString()
        {
            string line = string.Format($"BOXER: {base.FirstName} {base.LastName} from {base.Country}\n" +
                                        $"Category: {this.Category.ToString()}\n" +
                                        $"Wins: {this.Wins.ToString()}\n" +
                                        $"Losses: {this.Losses.ToString()}\n");
            return line;
        }
    }
}
