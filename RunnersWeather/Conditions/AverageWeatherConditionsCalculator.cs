using System.Collections.Generic;
using System.Linq;

namespace RunnersWeather.Conditions
{
    public class AverageWeatherConditionsCalculator
    {
        public static WeatherConditions Calculate(List<WeatherConditions> conditions)
        {
            WeatherConditions averageConditions = new WeatherConditions() { Provider = "Averages (calculated)" };

            foreach (var propertyName in GetFloatPropertiesNames(conditions[0]))
            {
                var property = conditions[0].GetType().GetProperty(propertyName);

                var averageQuery = from cond in conditions
                                   where property.GetValue(cond) != null
                                   select (float)property.GetValue(cond);

                property.SetValue(averageConditions, averageQuery.Average());
            }

            var weatherType = from cond in conditions 
                              where cond.WEATHERTYPE != null
                              select cond.WEATHERTYPE;

            if (weatherType.Count() > 0)
                averageConditions.WEATHERTYPE = weatherType.FirstOrDefault();

            return averageConditions;
        }

        private static List<string> GetFloatPropertiesNames(object source)
        {
            var result = new List<string>();

            foreach (var property in source.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(float?) || property.PropertyType == typeof(float))
                    result.Add(property.Name);
                    
            }

            return result;
        }
    }
}
