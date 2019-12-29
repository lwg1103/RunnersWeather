using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RunnersWeather.Conditions;

namespace RunnersWeather.Decision.Tests
{
    [TestClass()]
    public class DecisionMakerTests
    {
        [TestMethod()]
        public void isAGoodWeatherForRunningReturnsLowSmogIfPM25IsBetween26And50()
        {
            WeatherConditions conditions = createConditions(25, 30, 15, 30);

            Assert.AreEqual(DecisionType.LowSmog, DecisionMaker.CheckWeatherForRunning(conditions));
        }
        [TestMethod()]
        public void isAGoodWeatherForRunningReturnsLowHeavyIfPM25IsOver50()
        {
            WeatherConditions conditions = createConditions(25, 60, 15, 30);

            Assert.AreEqual(DecisionType.HeavySmog, DecisionMaker.CheckWeatherForRunning(conditions));
        }

        [TestMethod()]
        public void isAGoodWeatherForRunningReturnsColdIfTemperatureIsLow()
        {
            WeatherConditions conditions = createConditions(25, 15, -15, 30);

            Assert.AreEqual(DecisionType.TooCold, DecisionMaker.CheckWeatherForRunning(conditions));
        }

        [TestMethod()]
        public void isAGoodWeatherForRunningReturnsHotIfTemperatureAndHumidityAreHigh()
        {
            //40'C 35%
            Assert.AreEqual(DecisionType.TooHot, DecisionMaker.CheckWeatherForRunning(createConditions(25, 15, 40, 35)));

            //32'C 90%
            Assert.AreEqual(DecisionType.TooHot, DecisionMaker.CheckWeatherForRunning(createConditions(25, 15, 32, 90)));

            //36'C 60%
            Assert.AreEqual(DecisionType.TooHot, DecisionMaker.CheckWeatherForRunning(createConditions(25, 15, 36, 60)));
        }

        [TestMethod()]
        public void isAGoodWeatherForRunningReturnOkIfTemperatureHumiditySmogAreOk()
        {
            //35'C 35%
            Assert.AreEqual(DecisionType.OK, DecisionMaker.CheckWeatherForRunning(createConditions(25, 15, 35, 35)));

            //25'C 100%
            Assert.AreEqual(DecisionType.OK, DecisionMaker.CheckWeatherForRunning(createConditions(25, 15, 25, 100)));

            //30'C 60%
            Assert.AreEqual(DecisionType.OK, DecisionMaker.CheckWeatherForRunning(createConditions(25, 15, 30, 60)));
        }

        private WeatherConditions createConditions(float pm10, float pm25, float temp, float hum)
        {
            WeatherConditions conditions = new WeatherConditions();

            conditions.PM10 =           pm10;
            conditions.PM25 =           pm25;
            conditions.TEMPERATURE =    temp;
            conditions.HUMIDITY =       hum;

            return conditions;
        }
    }
}