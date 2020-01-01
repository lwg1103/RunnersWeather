﻿namespace RunnersWeather.Conditions
{
    public class WeatherConditions
    {
        public string Provider { get; set; } = "unknown";
        public float? PM25 { get; set; }
        public float? PM10 { get; set; }
        public float? TEMPERATURE { get; set; }
        public float? HUMIDITY { get; set; }
    }
}
