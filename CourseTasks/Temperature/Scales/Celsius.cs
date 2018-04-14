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

        public double ConvertFromCelsius(double value, IScale obj)
        {
            if (obj is Celsius)
            {
                return value;
            }

            if (obj is Fahrenheit)
            {
                return value * 9 / 5 + 32;
            }

            if (obj is Kelvin)
            {
                return value + 273.15;
            }

            return 0;
        }
    }
}