using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class Chair : Furniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, string material, decimal price,
            decimal height, int numberOfLegs)
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }
            private set
            {
                if (value > 0)
                {
                    this.numberOfLegs = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("numOfLegs");
                }
            }
        }

        public override string ToString()
        {
            string line = string.Format(
                "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}",
                base.GetType().Name, base.Model, base.Material,
                base.Price, base.Height, this.NumberOfLegs);
            return line;
        }
    }
}
