using RunnersWeather.Conditions;
using System;
using System.Linq;

namespace RunnersWeather.Decision
{
    public static class DecisionMaker
    {
        public static DecisionType CheckWeatherForRunning(WeatherConditions conditions)
        {
            /*****************
             * NO GO SECTION *
             *****************/
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
            else if (conditions.WIND >= 10)
            {
                return DecisionType.StrongWind;
            }
            
            switch (conditions.WEATHERTYPE)
            {
                case WeatherType.Rain:
                case WeatherType.Snow:
                case WeatherType.Thunderstorm:
                    return DecisionType.Rain;
            }

            /***************
             * MID SECTION *
             ***************/
            if (conditions.PM25 > 25 && conditions.PM25 <= 50)
            {
                return DecisionType.LowSmog;
            }

            switch (conditions.WEATHERTYPE)
            {
                case WeatherType.Drizzle:
                case WeatherType.Other:
                    return DecisionType.BadWeather;
            }

            /**************
             * OK SECTION *
             **************/
            return DecisionType.OK;
            
        }

        private static float calculateHeatFactor(WeatherConditions conditions)
        {
            float temp = conditions.TEMPERATURE ?? 0;
            float hum = conditions.HUMIDITY ?? 0;

            return (float)Math.Round(temp * 0.9 + hum * 0.25);
        }
    }
}