using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Scales
{
    public class Kelvin : IScale
    {
        private double value;

        public Kelvin()
        {
        }

        public double Value
        {
            get { return value; }
            set { this.value = value - 273.15; }
        }

        public double GetFinalTemperature(IScale obj)
        {
            Celsius temp = new Celsius();
            temp.Value = value;
            return temp.GetFinalTemperature(obj);
        }

        public string GetName()
        {
            return "кельвин";
        }
    }
}
