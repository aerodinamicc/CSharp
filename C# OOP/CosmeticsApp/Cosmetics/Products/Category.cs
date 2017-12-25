using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class Category : ICategory
    {
        private string name;
        private IList<IProduct> category;
        
        public Category(string name)
        {
            this.Name = name;
            this.category = new List<IProduct>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length > 15 || value.Length < 2)
                {
                    throw new IndexOutOfRangeException(
                        "Category name must be between 2 and 15 symbols long!");
                }
                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.category.Add(cosmetics);
        }

        public string Print()
        {
            StringBuilder builder = new StringBuilder();

            category = category.OrderByDescending(y => y.Price).OrderBy(x => x.Brand).ToList(); //
            if (category.Count > 0 && category.Count < 2)
            {
                string line = string.Format(
                    $"{this.Name} category - {this.category.Count} product in total" + "\n" +
                    $"{this.category[0].ToString()}");
                return line;
            }
            else if (category.Count > 1)
            {
                foreach (IProduct product in category)
                {
                    builder.AppendLine(product.ToString());
                }
                builder.Length -= 1;

                string line = string.Format(
                    $"{this.Name} category - {this.category.Count} products in total" + "\n" +
                    $"{builder}");
                return line;
            }
            else
            {
                string line = string.Format(
                    $"{this.Name} category - 0 products in total");
                return line;
            }
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            this.category.Remove(cosmetics);
        }
    }
}
