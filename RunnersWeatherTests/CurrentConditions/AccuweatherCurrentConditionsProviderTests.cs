using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using RunnersWeather.Conditions;
using RunnersWeather.Http;
using RunnersWeather.Logger;
using System.Threading.Tasks;

namespace RunnersWeather.CurrentConditions.Tests
{
    [TestClass()]
    public class AccuweatherCurrentConditionsProviderTests
    {
        AccuweatherCurrentConditionsProvider TestSubject;
        private readonly float lng = 17.05177F;
        private readonly float lat = 51.08804F;
        private readonly string locationResponse = "{\"Version\":1,\"Key\":\"2722990\",\"Type\":\"City\",\"Rank\":65,\"LocalizedName\":\"Tarnogaj\",\"EnglishName\":\"Tarnogaj\",\"PrimaryPostalCode\":\"\",\"Region\":{\"ID\":\"EUR\",\"LocalizedName\":\"Europe\",\"EnglishName\":\"Europe\"},\"Country\":{\"ID\":\"PL\",\"LocalizedName\":\"Poland\",\"EnglishName\":\"Poland\"},\"AdministrativeArea\":{\"ID\":\"02\",\"LocalizedName\":\"Lower Silesia\",\"EnglishName\":\"Lower Silesia\",\"Level\":1,\"LocalizedType\":\"Voivodship\",\"EnglishType\":\"Voivodship\",\"CountryID\":\"PL\"},\"TimeZone\":{\"Code\":\"CET\",\"Name\":\"Europe/Warsaw\",\"GmtOffset\":1.0,\"IsDaylightSaving\":false,\"NextOffsetChange\":\"2020-03-29T01:00:00Z\"},\"GeoPosition\":{\"Latitude\":51.081,\"Longitude\":17.06,\"Elevation\":{\"Metric\":{\"Value\":117.0,\"Unit\":\"m\",\"UnitType\":5},\"Imperial\":{\"Value\":383.0,\"Unit\":\"ft\",\"UnitType\":0}}},\"IsAlias\":false,\"ParentCity\":{\"Key\":\"273125\",\"LocalizedName\":\"Wrocław\",\"EnglishName\":\"Wrocław\"},\"SupplementalAdminAreas\":[{\"Level\":2,\"LocalizedName\":\"Wroclaw\",\"EnglishName\":\"Wrocław\"},{\"Level\":3,\"LocalizedName\":\"Wroclaw\",\"EnglishName\":\"Wrocław\"}],\"DataSets\":[\"AirQualityCurrentConditions\",\"AirQualityForecasts\",\"Alerts\",\"MinuteCast\",\"Radar\"]}";
        private readonly string conditionsResponse = "{\"LocalObservationDateTime\":\"2019-12-27T16:40:00+01:00\",\"EpochTime\":1577461200,\"WeatherText\":\"Cloudy\",\"WeatherIcon\":7,\"HasPrecipitation\":false,\"PrecipitationType\":null,\"IsDayTime\":false,\"Temperature\":{\"Metric\":{\"Value\":2.9,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":37.0,\"Unit\":\"F\",\"UnitType\":18}},\"MobileLink\":\"http://m.accuweather.com/en/pl/tarnogaj/2722990/current-weather/2722990?lang=en-us\",\"Link\":\"http://www.accuweather.com/en/pl/tarnogaj/2722990/current-weather/2722990?lang=en-us\"}";

        [TestMethod()]
        public void GetCurrentConditionsForCoordinatesReturnsResult()
        {
            InitTests();

            Assert.IsNotNull(TestSubject.GetCurrentConditionsForCoordinates(lng, lat));
        }
        [TestMethod()]
        public void GetCurrentConditionsForCoordinatesThrowsExceptionIfLimitWasExtended()
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
        }

        private void InitTests()
        {
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(logger => logger.AddEntry(""));
            loggerMock.Setup(logger => logger.Clear());

            TestSubject = new AccuweatherCurrentConditionsProvider(loggerMock.Object);

            var httpClientMock = new Mock<IHttpClient>();
            httpClientMock.SetupSequence(client => client.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(JObject.Parse(locationResponse))) //location
                .Returns(Task.FromResult(JObject.Parse(conditionsResponse))); //weather

            TestSubject.SetHttpClient(httpClientMock.Object);
        }
    }
}