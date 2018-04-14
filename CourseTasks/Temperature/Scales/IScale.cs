using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Scales
{
    public interface IScale
    {
        string Name { get; }

        double ConvertToCelsius(double value);
        double ConvertFromCelsius(double value, IScale obj);
    }
}