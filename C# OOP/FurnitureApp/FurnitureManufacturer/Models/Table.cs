using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class Table : Furniture,  ITable
    {
        private decimal length;
        private decimal width;
        private decimal area;

        public Table(string model, string material, decimal price, 
            decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
            this.area = this.Width * this.Length;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value > 0)
                {
                    this.length = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("length");
                }
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("width");
                }
            }
        }

        public decimal Area
        {
            get
            {
                return this.area;
            }
            private set
            {
                this.area = this.Length * this.Width;
            }
        }

        public override string ToString()
        {
            string line = string.Format(
                "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}",
                base.GetType().Name, base.Model, base.Material,
                base.Price, base.Height, this.Length, this.Width, this.Area);
            return line;
        }
    }
}
