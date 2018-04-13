using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Scales
{
    public class Celsius : IScale
    {
        private double value;

        public Celsius ()
        {
        }

        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public double GetFinalTemperature(IScale obj)
        {
            if(obj is Celsius)
            {
                return value;
            }

            if(obj is Fahrenheit)
            {
                return value * 9 / 5 + 32;
            }

            if(obj is Kelvin)
            {
                return value + 273.15;
            }

            return 0;
        }

        public string GetName()
        {
            return "цельсий";
        }
    }
}
