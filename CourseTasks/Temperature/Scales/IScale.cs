using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature.Scales
{
    public interface IScale
    {
        double Value { get; set; }

        double GetFinalTemperature(IScale obj);
        string GetName();
    }
}
