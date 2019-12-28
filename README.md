# RunnersWeather Information

## Goal
The goal of this application is to provide information if the weather is good for running outdoor.

## Data Sources
Currently data is fetched from Airly (smog, temperature, humidity) and OpenWeather (temperature - real feel, humidity)

## Criterias
```
if (conditions.PM25 > 25 && conditions.PM25 <= 50)
    {
        return DecisionType.LowSmog;
    }
    else if (conditions.PM25 > 50)
    {
        return DecisionType.HeavySmog;
    }
    else if (conditions.TEMPERATURE < 0)
    {
        return DecisionType.TooCold;
    }
    else if (conditions.TEMPERATURE >= 30 && Math.Round(conditions.TEMPERATURE*0.9 + conditions.HUMIDITY*0.25) >= 45)
    {
        return DecisionType.TooHot;
    }
    else
    {
        return DecisionType.OK;
    }
```

At the moment it is not possible to set custom criteria, however this feature is on the roadmap.

****

# Changelog
## 1.0.0 
Application shows data from Airly and OpenWeather and print information if the weather is good for running.