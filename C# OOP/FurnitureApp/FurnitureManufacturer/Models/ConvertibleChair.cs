using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted;
        private readonly decimal normalHeigth;

        public ConvertibleChair(string model, string material,
            decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.isConverted = false;
            this.normalHeigth = height;
        }

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }
            private set
            {
                this.isConverted = value;
            }
        }

        public void Convert()
        {
            if (IsConverted == false)
            {
                IsConverted = true;
                base.Height = 0.10m;
            }
            else if (IsConverted == true)
            {
                IsConverted = false;
                base.Height = normalHeigth;
            }
        }

        public override string ToString()
        {
            string line = string.Format(
                $"{base.ToString()}" + ", State: {0}",
                this.IsConverted ? "Converted" : "Normal");
            return line;
        }
    }
}
