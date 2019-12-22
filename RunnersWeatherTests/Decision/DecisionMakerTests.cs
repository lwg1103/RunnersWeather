using Microsoft.VisualStudio.TestTools.UnitTesting;
using RunnersWeather.Decision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunnersWeather.Conditions;

namespace RunnersWeather.Decision.Tests
{
    [TestClass()]
    public class DecisionMakerTests
    {
        [TestMethod()]
        public void isAGoodWeatherForRunningTellsNoIfPM25IsHigh()
        {
            WeatherConditions conditions = createConditions(25, 30, 15, 30);

            List<WeatherConditions> conditionList = new List<WeatherConditions>();
            conditionList.Add(conditions);

            Assert.IsFalse(DecisionMaker.isAGoodWeatherForRunning(conditionList));
        }

        [TestMethod()]
        public void isAGoodWeatherForRunningTellsNoIfTemperatureIsLow()
        {
            WeatherConditions conditions = createConditions(25, 15, -15, 30);

            List<WeatherConditions> conditionList = new List<WeatherConditions>();
            conditionList.Add(conditions);

            Assert.IsFalse(DecisionMaker.isAGoodWeatherForRunning(conditionList));
        }

        [TestMethod()]
        public void isAGoodWeatherForRunningTellsNoIfTemperatureAndHumidityAreHigh()
        {
            List<WeatherConditions> conditionList = new List<WeatherConditions>();

            //40'C 35%
            conditionList.Add(createConditions(25, 15, 40, 35));
            Assert.IsFalse(DecisionMaker.isAGoodWeatherForRunning(conditionList));
            conditionList.Clear();

            //32'C 90%
            conditionList.Add(createConditions(25, 15, 32, 90));
            Assert.IsFalse(DecisionMaker.isAGoodWeatherForRunning(conditionList));
            conditionList.Clear();

            //36'C 60%
            conditionList.Add(createConditions(25, 15, 36, 60));
            Assert.IsFalse(DecisionMaker.isAGoodWeatherForRunning(conditionList));
            conditionList.Clear();
        }

        [TestMethod()]
        public void isAGoodWeatherForRunningTellsYesIfTemperatureHumiditySmogAreOk()
        {
            List<WeatherConditions> conditionList = new List<WeatherConditions>();

            //35'C 35%
            conditionList.Add(createConditions(25, 15, 35, 35));
            Assert.IsTrue(DecisionMaker.isAGoodWeatherForRunning(conditionList));
            conditionList.Clear();

            //25'C 100%
            conditionList.Add(createConditions(25, 15, 25, 100));
            Assert.IsTrue(DecisionMaker.isAGoodWeatherForRunning(conditionList));
            conditionList.Clear();

            //30'C 60%
            conditionList.Add(createConditions(25, 15, 30, 60));
            Assert.IsTrue(DecisionMaker.isAGoodWeatherForRunning(conditionList));
            conditionList.Clear();
        }

        [TestMethod()]
        public void isAGoodWeatherForRunningCalculateResultFromAverges()
        {
            List<WeatherConditions> conditionList = new List<WeatherConditions>();

            //35'C 35%
            conditionList.Add(createConditions(25, 15, 30, 40));
            conditionList.Add(createConditions(25, 15, 40, 30));
            Assert.IsTrue(DecisionMaker.isAGoodWeatherForRunning(conditionList));
            conditionList.Clear();

            //25'C 100%
            conditionList.Add(createConditions(25, 15, 35, 100));
            conditionList.Add(createConditions(25, 15, 15, 100));
            Assert.IsTrue(DecisionMaker.isAGoodWeatherForRunning(conditionList));
            conditionList.Clear();

            //30'C 60%
            conditionList.Add(createConditions(25, 15, 20, 50));
            conditionList.Add(createConditions(25, 15, 40, 70));
            Assert.IsTrue(DecisionMaker.isAGoodWeatherForRunning(conditionList));
            conditionList.Clear();

            //40'C 35%
            conditionList.Add(createConditions(25, 15, 40, 35));
            conditionList.Add(createConditions(25, 15, 30, 34));
            conditionList.Add(createConditions(25, 15, 50, 36));
            Assert.IsFalse(DecisionMaker.isAGoodWeatherForRunning(conditionList));
            conditionList.Clear();

            //32'C 90%
            conditionList.Add(createConditions(25, 15, 33, 90));
            conditionList.Add(createConditions(25, 15, 31, 90));
            Assert.IsFalse(DecisionMaker.isAGoodWeatherForRunning(conditionList));
            conditionList.Clear();

            //36'C 60%
            conditionList.Add(createConditions(25, 15, 36, 55));
            conditionList.Add(createConditions(25, 15, 36, 65));
            Assert.IsFalse(DecisionMaker.isAGoodWeatherForRunning(conditionList));
            conditionList.Clear();

            //PM25 = 30
            conditionList.Add(createConditions(25, 40, 30, 40));
            conditionList.Add(createConditions(25, 20, 40, 30));
            Assert.IsFalse(DecisionMaker.isAGoodWeatherForRunning(conditionList));
            conditionList.Clear();

            //PM25 = 20
            conditionList.Add(createConditions(25, 30, 30, 40));
            conditionList.Add(createConditions(25, 10, 40, 30));
            Assert.IsTrue(DecisionMaker.isAGoodWeatherForRunning(conditionList));
            conditionList.Clear();
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