using Newtonsoft.Json.Linq;
using RunnersWeather.Conditions;
using RunnersWeather.Http;
using RunnersWeather.Logger;
using System.Threading.Tasks;

namespace RunnersWeather.CurrentConditions
{
    public class OpenWeatherCurrentConditionsProvider : BaseConditionsProvider, ICurrentConditionsProvider
    {
        private readonly ILogger logger;
        private readonly string APIKey = "1fcb7d183cfcaeb5b72ee5407b766d55";
        private readonly string url = "http://api.openweathermap.org/data/2.5/weather?";
        private IHttpClient httpClient = HttpClient.Instance;
        public void SetHttpClient(IHttpClient client) => httpClient = client;

        public OpenWeatherCurrentConditionsProvider(ILogger logger) => this.logger = logger;

        public async Task<WeatherConditions> GetCurrentConditionsForCoordinates(float lng, float lat)
        {
            PrintStartInfo(lng, lat);

            JObject result = await GetStatusFromAPI(lng, lat);

            WeatherConditions conditions = ParseWeatherConditionFromJsonResult(result);

            PrintConditionsInfo(conditions);
            
            return conditions;
        }
        
        private void PrintConditionsInfo(WeatherConditions conditions)
        {
            logger.AddEntry($"PM25: {conditions.PM25}");
            logger.AddEntry($"PM10: {conditions.PM10}");
            logger.AddEntry($"TEMPERATURE: {conditions.TEMPERATURE}");
            logger.AddEntry($"HUMIDITY: {conditions.HUMIDITY}");
        }

        private async Task<JObject> GetStatusFromAPI(float lng, float lat)
        {
            httpClient.Init();
            JObject result = await httpClient.GetAsync($"{url}lat={lat.ToString("F5")}&lon={lng.ToString("F5")}&appid={APIKey}");
            return result;
        }

        private void PrintStartInfo(float lng, float lat)
        {
            logger.AddEntry($"Checking conditions for long: {lng} and lat: {lat} on OpenWeather");
        }

        private static WeatherConditions ParseWeatherConditionFromJsonResult(JObject result)
        {
            WeatherConditions conditions = new WeatherConditions();

            conditions.TEMPERATURE = result["main"]["feels_like"].Value<float>() - 272.15f; //response in K
            conditions.HUMIDITY = result["main"]["humidity"].Value<float>();

            return conditions;
        }
    }
}
