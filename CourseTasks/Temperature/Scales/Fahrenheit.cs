using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Scales
{
    public class Fahrenheit : IScale
    {
        public string Name
        {
            get { return "фаренгейт"; }
        }

        public double ConvertToCelsius(double value)
        {
            return (value - 32) * 5 / 9;
        }

        public double ConvertFromCelsius(double value)
        {
            return value * 9 / 5 + 32;
        }
    }
}