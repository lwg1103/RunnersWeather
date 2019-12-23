using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RunnersWeather.Logger;
using RunnersWeather.CurrentConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunnersWeather.Conditions;

namespace RunnersWeather.CurrentConditions.Tests
{
    [TestClass()]
    public class AirlyCurrentConditionsProviderTests
    {
        AirlyCurrentConditionsProvider TestSubject;
        private readonly float lng = 17.05177F;
        private readonly float lat = 51.08804F;

        [TestMethod()]
        public void GetCurrentSmogConditionsForCoordinatesReturnsResult()
        {
            initTests();

            Assert.IsNotNull(TestSubject.GetCurrentConditionsForCoordinates(lng, lat));
        }

        [TestMethod()]
        public void GetCurrentSmogConditionsForCoordinatesReturnsWeatherConditionsObject()
        {
            initTests();

            Assert.IsInstanceOfType(TestSubject.GetCurrentConditionsForCoordinates(lng, lat), typeof(Task<WeatherConditions>));
        }

        [TestMethod()]
        public void GetCurrentSmogConditionsForCoordinatesReturnsWeatherConditionsWithValues()
        {
            initTests();

            var actualconditions = TestSubject.GetCurrentConditionsForCoordinates(lng, lat);
            var emptyConditions = new WeatherConditions();

            Assert.AreNotEqual(emptyConditions.PM10,        actualconditions.Result.PM10);
            Assert.AreNotEqual(emptyConditions.PM25,        actualconditions.Result.PM25);
            Assert.AreNotEqual(emptyConditions.TEMPERATURE, actualconditions.Result.TEMPERATURE);
            Assert.AreNotEqual(emptyConditions.HUMIDITY,    actualconditions.Result.HUMIDITY);
        }

        private void initTests()
        {
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(logger => logger.AddEntry(""));
            loggerMock.Setup(logger => logger.Clear());

            TestSubject = new AirlyCurrentConditionsProvider(loggerMock.Object);
        }
    }
}