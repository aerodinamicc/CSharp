using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {
        private IList<string> ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender,
            IList<string> ingredients) : base(name, brand, price, gender)
        {
            this.Ingredients = string.Join(" ", ingredients);
        }

        public string Ingredients
        {
            get
            {
                return string.Join(", ",this.ingredients);
            }
            private set
            {
                this.ingredients = value.Split(' ');
            }
        }

        public override string ToString()
        {
            string line = string.Format(
                $"- {base.Print()}" + "\n" +
                $"  * For gender: {base.Gender}" + "\n" +
                $"  * Ingredients: {this.Ingredients}");
            return line; 
        }
    }
}
