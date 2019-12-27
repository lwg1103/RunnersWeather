using RunnersWeather.Conditions;
using RunnersWeather.Logger;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RunnersWeather.Http;

namespace RunnersWeather.CurrentConditions
{
    public class AccuweatherCurrentConditionsProvider : BaseConditionsProvider, ICurrentConditionsProvider
    {
        private ILogger logger;
        private readonly string APIKey = "I9MHNG84XD5dtmuAeXqGqE3aZANdPiL7";
        private readonly string locationUrl = "http://dataservice.accuweather.com/locations/v1/cities/geoposition/search?";
        private readonly string conditionsUrl = "http://dataservice.accuweather.com/currentconditions/v1/";
        private IHttpClient httpClient = HttpClient.Instance;
        public void SetHttpClient(IHttpClient client) => httpClient = client;

        public AccuweatherCurrentConditionsProvider(ILogger logger) => this.logger = logger;

        public async Task<WeatherConditions> GetCurrentConditionsForCoordinates(float lng, float lat)
        {
            PrintStartInfo(lng, lat);

            JObject locationResult = await GetLocation(lng, lat);
            string locationKey = ParseLocationKey(locationResult);

            JObject result = await GetCurrentConditions(locationKey);

            WeatherConditions conditions = ParseWeatherConditionFromJsonResult(result);

            PrintConditionsInfo(conditions);

            return conditions;
        }

        private void PrintStartInfo(float lng, float lat)
        {
            logger.AddEntry($"Checking conditionsr for long: {lng} and lat: {lat} on Accuweather");
        }
        private async Task<JObject> GetLocation(float lng, float lat)
        {
            var httpClient = Http.HttpClient.Instance;
            httpClient.Init();
            JObject result = await httpClient.GetAsync($"{locationUrl}q={lat.ToString("F5")},{lng.ToString("F5")}&apikey={APIKey}");
            return result;
        }

        private async Task<JObject> GetCurrentConditions(string locationKey)
        {
            var httpClient = Http.HttpClient.Instance;
            httpClient.Init();
            JObject result = await httpClient.GetAsync($"{conditionsUrl}{locationKey}?apikey={APIKey}");
            return result;
        }

        private string ParseLocationKey(JObject result)
        {
            return result["Key"].ToString();
        }

        private static WeatherConditions ParseWeatherConditionFromJsonResult(JObject result)
        {
            WeatherConditions conditions = new WeatherConditions();

            conditions.TEMPERATURE = result["Temperature"]["Metric"]["Value"].Value<float>();

            return conditions;
        }

        private void PrintConditionsInfo(WeatherConditions conditions)
        {
            logger.AddEntry($"PM25: {conditions.PM25}");
            logger.AddEntry($"PM10: {conditions.PM10}");
            logger.AddEntry($"TEMPERATURE: {conditions.TEMPERATURE}");
            logger.AddEntry($"HUMIDITY: {conditions.HUMIDITY}");
        }
    }
}
