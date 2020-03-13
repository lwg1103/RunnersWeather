using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace RunnersWeather.Conditions.Tests
{
    [TestClass()]
    public class AverageWeatherConditionsCalculatorTests
    {
        [TestMethod()]
        public void CalculateAverages()
        {
            List<WeatherConditions> conditions = new List<WeatherConditions>();

            conditions.Add(new WeatherConditions
            {
                PM10 = 5.2f,
                PM25 = 10.4f,
                TEMPERATURE = 15.1f,
                HUMIDITY = 89.0f,
                WIND = 2.0f
            });

            conditions.Add(new WeatherConditions
            {
                PM10 = 5.4f,
                PM25 = 15.4f,
                TEMPERATURE = 25.1f,
                HUMIDITY = 88.0f,
                WIND = 3.0f
            });

            WeatherConditions expected = new WeatherConditions
            {
                PM10 = 5.3f,
                PM25 = 12.9f,
                TEMPERATURE = 20.1f,
                HUMIDITY = 88.5f,
                WIND = 2.5f
            };

            WeatherConditions actual = AverageWeatherConditionsCalculator.Calculate(conditions);

            Assert.AreEqual(expected.PM10, actual.PM10);
            Assert.AreEqual(expected.PM25, actual.PM25);
            Assert.AreEqual(expected.TEMPERATURE, actual.TEMPERATURE);
            Assert.AreEqual(expected.HUMIDITY, actual.HUMIDITY);
            Assert.AreEqual(expected.WIND, actual.WIND);
        }

        [TestMethod()]
        public void CalculateAveragesWithNullValues()
        {
            List<WeatherConditions> conditions = new List<WeatherConditions>();

            conditions.Add(new WeatherConditions
            {
                PM25 = 10.4f,
                TEMPERATURE = 15.1f,
                HUMIDITY = 89.0f,
                WIND = 2.5f
            });

            conditions.Add(new WeatherConditions
            {
                PM10 = 5.4f,
                PM25 = 15.4f,
                HUMIDITY = 88.0f
            });

            WeatherConditions expected = new WeatherConditions
            {
                PM10 = 5.4f,
                PM25 = 12.9f,
                TEMPERATURE = 15.1f,
                HUMIDITY = 88.5f,
                WIND = 2.5f
            };

            WeatherConditions actual = AverageWeatherConditionsCalculator.Calculate(conditions);

            Assert.AreEqual(expected.PM10, actual.PM10);
            Assert.AreEqual(expected.PM25, actual.PM25);
            Assert.AreEqual(expected.TEMPERATURE, actual.TEMPERATURE);
            Assert.AreEqual(expected.HUMIDITY, actual.HUMIDITY);
            Assert.AreEqual(expected.WIND, actual.WIND);
        }

        [TestMethod()]
        public void CalculateAveragesWithWeatherType()
        {
            List<WeatherConditions> conditions = new List<WeatherConditions>();

            conditions.Add(new WeatherConditions
            {
                PM25 = 10.4f,
                TEMPERATURE = 15.1f,
                HUMIDITY = 89.0f,
                WIND = 2.5f,
                WEATHERTYPE = WeatherType.Drizzle
            });

            conditions.Add(new WeatherConditions
            {
                PM10 = 5.4f,
                PM25 = 15.4f,
                HUMIDITY = 88.0f
            });

            WeatherConditions expected = new WeatherConditions
            {
                PM10 = 5.4f,
                PM25 = 12.9f,
                TEMPERATURE = 15.1f,
                HUMIDITY = 88.5f,
                WIND = 2.5f,
                WEATHERTYPE = WeatherType.Drizzle
            };

            WeatherConditions actual = AverageWeatherConditionsCalculator.Calculate(conditions);

            Assert.AreEqual(expected.PM10, actual.PM10);
            Assert.AreEqual(expected.PM25, actual.PM25);
            Assert.AreEqual(expected.TEMPERATURE, actual.TEMPERATURE);
            Assert.AreEqual(expected.HUMIDITY, actual.HUMIDITY);
            Assert.AreEqual(expected.WIND, actual.WIND);
            Assert.AreEqual(expected.WEATHERTYPE, actual.WEATHERTYPE);
        }
    }
}