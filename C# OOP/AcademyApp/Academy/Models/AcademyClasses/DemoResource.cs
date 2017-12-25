using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.AcademyClasses
{
    public class DemoResource : ILectureResource
    {
        private string name;
        private string url;

        public DemoResource(string name, string url)
        {
            this.Name = name;
            this.Url = url;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length >2 &&
                    value.Length < 16)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException(
                        "Resource name should be between 3 and 15 symbols long!");
                }
            }
        }
        public string Url
        {
            get
            {
                return this.url;
            }
            set 
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 4 &&
                    value.Length < 151)
                {
                    this.url = value;
                }
                else
                {
                    throw new ArgumentException(
                        "Resource url should be between 5 and 150 symbols long!");
                }
            }
        }

        public override string ToString()
        {
            return $"    * Resource:\n" +
                   $"     - Name: {this.Name}\n" +
                   $"     - Url: {this.Url}\n" +
                   $"     - Type: Demo";
        }
    }
}
