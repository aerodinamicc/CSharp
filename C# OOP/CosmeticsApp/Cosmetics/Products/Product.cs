using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;

namespace Cosmetics.Products
{
    public class Product : IProduct

    {
        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (value.Length < 3 || value.Length > 10)
                {
                    throw new ArgumentException(
                        "Product name must be between 3 and 10 symbols long!");
                }
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            protected set
            {
                if (value.Length < 2 || value.Length > 10)
                {
                    throw new ArgumentException(
                        "Product brand must be between 2 and 10 symbols long!");
                }
                this.brand = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                this.price = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
            protected set
            {
                this.gender = value;
            }
        }

        public string Print()
        {
            string line = string.Format(
                $"- {this.Brand} - {this.Name}" +
                $"   * Price: ${this.Price}" +
                $"   * For gender: {nameof(this.Gender)}");

            return line;
        }
    }
}
