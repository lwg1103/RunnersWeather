using Microsoft.VisualStudio.TestTools.UnitTesting;
using RunnersWeather.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunnersWeather.CurrentConditions;

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
                HUMIDITY = 89.0f
            });

            conditions.Add(new WeatherConditions
            {
                PM10 = 5.4f,
                PM25 = 15.4f,
                TEMPERATURE = 25.1f,
                HUMIDITY = 88.0f
            });

            WeatherConditions expected = new WeatherConditions
            {
                PM10 = 5.3f,
                PM25 = 12.9f,
                TEMPERATURE = 20.1f,
                HUMIDITY = 88.5f
            };

            WeatherConditions actual = AverageWeatherConditionsCalculator.Calculate(conditions);

            Assert.AreEqual(expected.PM10, actual.PM10);
            Assert.AreEqual(expected.PM25, actual.PM25);
            Assert.AreEqual(expected.TEMPERATURE, actual.TEMPERATURE);
            Assert.AreEqual(expected.HUMIDITY, actual.HUMIDITY);
        }

        [TestMethod()]
        public void CalculateAveragesWithNullValues()
        {
            List<WeatherConditions> conditions = new List<WeatherConditions>();

            conditions.Add(new WeatherConditions
            {
                PM25 = 10.4f,
                TEMPERATURE = 15.1f,
                HUMIDITY = 89.0f
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
                HUMIDITY = 88.5f
            };

            WeatherConditions actual = AverageWeatherConditionsCalculator.Calculate(conditions);

            Assert.AreEqual(expected.PM10, actual.PM10);
            Assert.AreEqual(expected.PM25, actual.PM25);
            Assert.AreEqual(expected.TEMPERATURE, actual.TEMPERATURE);
            Assert.AreEqual(expected.HUMIDITY, actual.HUMIDITY);
        }
    }
}