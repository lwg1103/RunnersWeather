using System.Collections.Generic;

namespace RunnersWeather.Conditions
{
    public class AverageWeatherConditionsCalculator
    {
        public static WeatherConditions Calculate(List<WeatherConditions> conditions)
        {
            float pm10 = 0, pm25 = 0, humidity = 0, temperature = 0;
            int pm10Counter = 0, pm25Counter = 0, humidityCounter = 0, temperatureCounter = 0;

            foreach (var condition in conditions)
            {
                if (condition.PM10.HasValue)
                {
                    pm10 += condition.PM10.Value;
                    pm10Counter++;
                }
                if (condition.PM25.HasValue)
                {
                    pm25 += condition.PM25.Value;
                    pm25Counter++;
                }
                if (condition.HUMIDITY.HasValue)
                {
                    humidity += condition.HUMIDITY.Value;
                    humidityCounter++;
                }
                if (condition.TEMPERATURE.HasValue)
                {
                    temperature += condition.TEMPERATURE.Value;
                    temperatureCounter++;
                }
            }

            return new WeatherConditions
            {
                PM10 = pm10 / pm10Counter,
                PM25 = pm25 / pm25Counter,
                HUMIDITY = humidity / humidityCounter,
                TEMPERATURE = temperature / temperatureCounter
            };
        }
    }
}
