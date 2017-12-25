using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.Olympics.Models
{
    public static class Convertion
    {
        public static IDictionary<string, double> StringToDict(IList<string> list)
        {
            IDictionary<string, double> dict =
            new Dictionary<string, double>();
            dict = list.Skip(3).Select(part =>
            part.Split('/')).
            ToDictionary(split => split[0],
            split => double.Parse(split[1]));
            return dict;
        }
    }
}
