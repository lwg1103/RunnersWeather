using System.Threading.Tasks;
using RunnersWeather.Conditions;
using Newtonsoft.Json.Linq;
using RunnersWeather.Logger;
using RunnersWeather.Http;

namespace RunnersWeather.CurrentConditions
{
    public abstract class BaseConditionsProvider : ICurrentConditionsProvider
    {
        protected  readonly ILogger logger;
        protected abstract string Name { get; }
        private IHttpClient httpClient = Http.HttpClient.Instance;
        public IHttpClient HttpClient
        {
            get => httpClient;
            set { httpClient = value; }
        }

        public BaseConditionsProvider(ILogger logger) => this.logger = logger;

        public async Task<WeatherConditions> GetCurrentConditionsForCoordinates(float lng, float lat)
        {
            PrintStartInfo(lng, lat);

            JObject result = await GetStatusFromAPI(lng, lat);

            WeatherConditions conditions = ParseWeatherConditionFromJsonResult(result);

            PrintConditionsInfo(conditions);

            return conditions;
        }

        protected abstract Task<JObject> GetStatusFromAPI(float lng, float lat);
        protected abstract WeatherConditions ParseWeatherConditionFromJsonResult(JObject result);
        protected void PrintStartInfo(float lng, float lat)
        {
            logger.AddEntry($"Checking conditions for long: {lng} and lat: {lat} on {Name}");
        }
        protected void PrintConditionsInfo(WeatherConditions conditions)
        {
            logger.AddEntry($"PM25: {conditions.PM25}");
            logger.AddEntry($"PM10: {conditions.PM10}");
            logger.AddEntry($"TEMPERATURE: {conditions.TEMPERATURE}");
            logger.AddEntry($"HUMIDITY: {conditions.HUMIDITY}");
        }
    }
}
