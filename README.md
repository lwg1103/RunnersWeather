# RunnersWeather Information

## Goal
The goal of this application is to provide information if the weather is good for running outdoor.

## Data Sources
Currently data is fetched from Airly (smog, temperature, humidity) and OpenWeather (temperature - real feel, humidity)

## Criterias
```

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
```

At the moment it is not possible to set custom criteria, however this feature is on the roadmap.

****

# Changelog
## 1.3.0
Rain conditions added
## 1.2.0
Wind speed added
## 1.1.0
City selector added, now user can select predefined area insted of typing geo coords manually 
## 1.0.1
Fixed average condition calculation when some values are null
## 1.0.0 
Application shows data from Airly and OpenWeather and print information if the weather is good for running.