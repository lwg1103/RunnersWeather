using RunnersWeather.Conditions;

namespace RunnersWeather.CurrentConditions
{
    public class OpenWeatherTypeConverter : IWeatherTypeConventer
    {
        public WeatherType ConvertFromProviderFormat(object source)
        {
            //https://openweathermap.org/weather-conditions

            int intSource = (int)source;

            if (intSource < 300)
            {
                return WeatherType.Thunderstorm;
            } 
            else if (intSource < 400) 
            {
                return WeatherType.Drizzle;
            }
            else if (intSource < 600)
            {
                return WeatherType.Rain;
            }
            else if (intSource < 700)
            {
                return WeatherType.Snow;
            }
            else if (intSource == 800)
            {
                return WeatherType.Clear;
            }
            else if (intSource > 800)
            {
                return WeatherType.Clouds;
            }

            return WeatherType.Other;
        }
    }
}
