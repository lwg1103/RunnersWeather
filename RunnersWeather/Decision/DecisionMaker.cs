using RunnersWeather.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnersWeather.Decision
{
    public static class DecisionMaker
    {
        public static bool isAGoodWeatherForRunning(List<RunnersWeather.Conditions.WeatherConditions> conditions)
        {
            WeatherConditions averageCondition = calculateAverages(conditions);

            return isAGoodWeather(averageCondition);
        }

        private static WeatherConditions calculateAverages(List<WeatherConditions> conditions)
        {
            WeatherConditions averageConditions = new WeatherConditions();

            foreach (var condition in conditions)
            {
                averageConditions.PM10 += condition.PM10;
                averageConditions.PM25 += condition.PM25;
                averageConditions.HUMIDITY += condition.HUMIDITY;
                averageConditions.TEMPERATURE += condition.TEMPERATURE;
            }

            averageConditions.PM10 /=           (float)conditions.Count;
            averageConditions.PM25 /=           (float)conditions.Count;
            averageConditions.HUMIDITY /=       (float)conditions.Count;
            averageConditions.TEMPERATURE /=    (float)conditions.Count;

            return averageConditions;
        }
        private static bool isAGoodWeather(WeatherConditions conditions)
        {
            if (conditions.PM25 > 25)
            {
                return false;
            }
            else if (conditions.TEMPERATURE < 0)
            {
                return false;
            }
            else if (conditions.TEMPERATURE >= 30 && Math.Round(conditions.TEMPERATURE*0.9 + conditions.HUMIDITY*0.25) >= 45)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}