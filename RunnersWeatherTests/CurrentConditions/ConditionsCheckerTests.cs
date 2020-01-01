using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RunnersWeather.Conditions;
using RunnersWeather.CurrentConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnersWeather.CurrentConditions.Tests
{
    [TestClass()]
    public class ConditionsCheckerTests
    {
        IConditionsChecker TestSubject = new ConditionsChecker();

        [TestMethod()]
        public void GetCurrentConditionsForCoordinatesThrowsExceptionIfNoProvidersRegistered()
        {
            Assert.ThrowsExceptionAsync<NoProvidersRegistered>(callGetCurrentConditionsForCoordinates);
        }

        [TestMethod()]
        public void GetCurrentConditionsForCoordinatesReturnsResultFromProvider()
        {
            WeatherConditions weatherConditions = new WeatherConditions();

            TestSubject.RegisterCurrentConditionProvider(GetCurrentConditionsProviderMock(weatherConditions));

            List<WeatherConditions> results = callGetCurrentConditionsForCoordinates().Result;

            Assert.AreEqual(1, results.Count);
            Assert.IsTrue(results.Contains(weatherConditions));
        }

        [TestMethod()]
        public void GetCurrentConditionsForCoordinatesReturnsResultFromEachProvider()
        {
            WeatherConditions weatherConditions1 = new WeatherConditions();
            WeatherConditions weatherConditions2 = new WeatherConditions();

            TestSubject.RegisterCurrentConditionProvider(GetCurrentConditionsProviderMock(weatherConditions1));
            TestSubject.RegisterCurrentConditionProvider(GetCurrentConditionsProviderMock(weatherConditions2));

            List<WeatherConditions> results = callGetCurrentConditionsForCoordinates().Result;

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.Contains(weatherConditions1));
            Assert.IsTrue(results.Contains(weatherConditions2));
        }

        private async Task<List<WeatherConditions>> callGetCurrentConditionsForCoordinates()
        {
            return await TestSubject.GetCurrentConditionsForCoordinates(10.0f, 10.0f);
        }

        private ICurrentConditionsProvider GetCurrentConditionsProviderMock()
        {
            var mock = new Mock<ICurrentConditionsProvider>();

            mock.Setup(x => x.GetCurrentConditionsForCoordinates(It.IsAny<float>(), It.IsAny<float>()))
                .Returns(Task.FromResult(new Conditions.WeatherConditions()));

            return mock.Object;
        }

        private ICurrentConditionsProvider GetCurrentConditionsProviderMock(WeatherConditions returnedCondition)
        {
            var mock = new Mock<ICurrentConditionsProvider>();

            mock.Setup(x => x.GetCurrentConditionsForCoordinates(It.IsAny<float>(), It.IsAny<float>()))
                .Returns(Task.FromResult(returnedCondition));

            return mock.Object;
        }
    }
}