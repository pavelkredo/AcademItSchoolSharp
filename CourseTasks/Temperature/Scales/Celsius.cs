using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Scales
{
    public class Celsius : IScale
    {
        public string Name
        {
            get { return "цельсий"; }
        }

        public double ConvertToCelsius(double value)
        {
            return value;
        }

        public double ConvertFromCelsius(double value)
        {
            return value;
        }
    }
}