using Temperature.Scales;

namespace Temperature.Temperature
{
    public class TemperatureConvertion
    {
        public double ConvertTemperature(double value, IScale originalScale, IScale finalScale)
        {
            return finalScale.ConvertFromCelsius(originalScale.ConvertToCelsius(value));
        }
    }
}
