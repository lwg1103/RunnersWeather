using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using RunnersWeather.Conditions;

namespace RunnersWeather.CurrentConditions.Tests
{
    [TestClass()]
    public class OpenWeatherCurrentConditionsProviderTests : CurrentConditionsProviderTestsBase
    {
        protected override string APIResponse => "{\"coord\":{\"lon\":17.05,\"lat\":51.09},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04n\"}],\"base\":\"stations\",\"main\":{\"temp\":275.09,\"feels_like\":269.42,\"temp_min\":272.59,\"temp_max\":277.59,\"pressure\":1028,\"humidity\":100},\"visibility\":10000,\"wind\":{\"speed\":5.7,\"deg\":320},\"clouds\":{\"all\":75},\"dt\":1577465801,\"sys\":{\"type\":1,\"id\":1715,\"country\":\"PL\",\"sunrise\":1577429703,\"sunset\":1577458201},\"timezone\":3600,\"id\":3081368,\"name\":\"Wroclaw\",\"cod\":200}";
        protected override BaseConditionsProvider CreateTestSubject() => new OpenWeatherCurrentConditionsProvider();

        [TestMethod()]
        public void GetCurrentConditionsForCoordinatesReturnsResult()
        {
            InitTests();

            Assert.IsNotNull(TestSubject.GetCurrentConditionsForCoordinates(lng, lat));
        }

        [TestMethod()]
        public void GetCurrentConditionsForCoordinatesReturnsWeatherConditionsObject()
        {
            InitTests();

            Assert.IsInstanceOfType(TestSubject.GetCurrentConditionsForCoordinates(lng, lat), typeof(Task<WeatherConditions>));
        }

        [TestMethod()]
        public void GetCurrentConditionsForCoordinatesReturnsWeatherConditionsWithValues()
        {
            InitTests();

            var actualconditions = TestSubject.GetCurrentConditionsForCoordinates(lng, lat);
            var emptyConditions = new WeatherConditions();

            Assert.AreNotEqual(emptyConditions.TEMPERATURE, actualconditions.Result.TEMPERATURE);
            Assert.AreNotEqual(emptyConditions.HUMIDITY,    actualconditions.Result.HUMIDITY);
            Assert.AreNotEqual(emptyConditions.WIND, actualconditions.Result.WIND);
        }
    }
}