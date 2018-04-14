using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Scales
{
    public class Kelvin : IScale
    {
        public string Name
        {
            get { return "кельвин"; }
        }

        public double ConvertToCelsius(double value)
        {
            return value - 273.15;
        }

        public double ConvertFromCelsius(double value)
        {
            return value + 273.15;
        }
    }
}