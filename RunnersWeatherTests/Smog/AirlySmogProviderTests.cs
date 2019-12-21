using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RunnersWeather.Logger;
using RunnersWeather.Smog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunnersWeather.Conditions;

namespace RunnersWeather.Smog.Tests
{
    [TestClass()]
    public class AirlySmogProviderTests
    {
        AirlySmogProvider TestSubject;
        private readonly float lng = 17.05177F;
        private readonly float lat = 51.08804F;

        [TestMethod()]
        public void GetCurrentSmogConditionsForCoordinatesReturnsResult()
        {
            initTests();

            Assert.IsNotNull(TestSubject.GetCurrentSmogConditionsForCoordinates(lng, lat));
        }

        [TestMethod()]
        public void GetCurrentSmogConditionsForCoordinatesReturnsWeatherConditionsObject()
        {
            initTests();

            Assert.IsInstanceOfType(TestSubject.GetCurrentSmogConditionsForCoordinates(lng, lat), typeof(Task<WeatherConditions>));
        }

        [TestMethod()]
        public void GetCurrentSmogConditionsForCoordinatesReturnsWeatherConditionsWithValues()
        {
            initTests();

            var actualconditions = TestSubject.GetCurrentSmogConditionsForCoordinates(lng, lat);
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

            TestSubject = new AirlySmogProvider(loggerMock.Object);
        }
    }
}