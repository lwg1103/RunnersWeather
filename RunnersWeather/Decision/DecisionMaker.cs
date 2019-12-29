using RunnersWeather.Conditions;
using System;
using System.Collections.Generic;

namespace RunnersWeather.Decision
{
    public static class DecisionMaker
    {
        public static DecisionType CheckWeatherForRunning(WeatherConditions conditions)
        {
            if (conditions.PM25 > 50)
            {
                return DecisionType.HeavySmog;
            }
            else if (conditions.TEMPERATURE < 0)
            {
                return DecisionType.TooCold;
            }
            else if (conditions.TEMPERATURE >= 30 && calculateHeatFactor(conditions) >= 45)
            {
                return DecisionType.TooHot;
            }
            else if (conditions.PM25 > 25 && conditions.PM25 <= 50)
            {
                return DecisionType.LowSmog;
            }
            else
            {
                return DecisionType.OK;
            }
        }

        private static float calculateHeatFactor(WeatherConditions conditions)
        {
            float temp = conditions.TEMPERATURE ?? 0;
            float hum = conditions.HUMIDITY ?? 0;

            return (float)Math.Round(temp * 0.9 + hum * 0.25);
        }
    }
}