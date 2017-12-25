using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo
    {
        private uint milliliters;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender,
            uint milliliters, UsageType usage) : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Price = price * this.Milliliters;
            this.Usage = usage;
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }
            private set
            {
                this.milliliters = value;
            }
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }
            private set
            {
                this.usage = value;
            }
        }

        public override string ToString()
        {
            string line = string.Format(
                $" - {base.Print()}" + "\n" +
                $"  * Quantity: {this.milliliters} ml" + "\n" +
                $"  * Usage: {this.Usage}");
            return line; 
        }
    }
}
