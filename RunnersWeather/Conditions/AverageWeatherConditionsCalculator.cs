using System.Collections.Generic;
using System.Linq;

namespace RunnersWeather.Conditions
{
    public class AverageWeatherConditionsCalculator
    {
        public static WeatherConditions Calculate(List<WeatherConditions> conditions)
        {
            WeatherConditions averageConditions = new WeatherConditions() { Provider = "Averages (calculated)" };

            foreach (var propertyName in WeatherConditions.GetFloatPropertiesNames())
            {
                var property = conditions[0].GetType().GetProperty(propertyName);

                var averageQuery = from cond in conditions
                                   where property.GetValue(cond) != null
                                   select (float)property.GetValue(cond);

                property.SetValue(averageConditions, averageQuery.Average());
            }

            return averageConditions;
        }
    }
}
