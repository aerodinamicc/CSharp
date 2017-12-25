using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string regNumber)
        {
            this.Name = name;
            this.RegistrationNumber = regNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("CompanyName");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                //int regNum;
                if (value.Length != 10) //|| !int.TryParse(value, out regNum)
                {
                    throw new ArgumentException("Company's reg number");
                }
                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
            private set
            {
                this.furnitures = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public string Catalog()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format(
                            "{0} - {1} - {2} {3}" + "\n",
                            this.Name,
                            this.RegistrationNumber,
                            this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                            this.Furnitures.Count != 1 ? "furnitures" : "furniture"));

            if (this.furnitures.Count() > 0)
            {
                foreach (IFurniture piece in this.furnitures.OrderBy(x => x.Model).OrderBy(x => x.Price))
                {
                    builder.Append(piece.ToString() + "\n");
                }
            }
            builder.Length -= 1;
            return builder.ToString();
        }

        public IFurniture Find(string model)
        {
            foreach (IFurniture piece in this.furnitures)
            {
                if (piece.Model == model)
                {
                    return piece;
                }
            }
            return null;
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }
    }
}
