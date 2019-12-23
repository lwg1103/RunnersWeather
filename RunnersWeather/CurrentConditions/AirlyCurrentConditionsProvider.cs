using Newtonsoft.Json.Linq;
using RunnersWeather.Conditions;
using RunnersWeather.Logger;
using System.Threading.Tasks;

namespace RunnersWeather.CurrentConditions
{
    public class AirlyCurrentConditionsProvider : ICurrentConditionsProvider
    {
        private ILogger logger;
        private readonly string APIKey = "TcY7Pv87COniLs8ySsanDClgwG3hUTBn";
        private readonly string airlyUrl = "https://airapi.airly.eu/v2/measurements/point?";

        public AirlyCurrentConditionsProvider(ILogger logger) => this.logger = logger;

        public async Task<WeatherConditions> GetCurrentConditionsForCoordinates(float lng, float lat)
        {
            PrintStartInfo(lng, lat);

            JObject result = await GetStatusFromAirly(lng, lat);

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

        private async Task<JObject> GetStatusFromAirly(float lng, float lat)
        {
            var httpClient = Http.HttpClient.Instance;
            httpClient.InitWithApiKey(APIKey);
            JObject result = await httpClient.GetAsync($"{airlyUrl}lat={lat.ToString("F5")}&lng={lng.ToString("F5")}");
            return result;
        }

        private void PrintStartInfo(float lng, float lat)
        {
            logger.AddEntry($"Checking conditions for long: {lng} and lat: {lat} on Airly");
        }

        private static WeatherConditions ParseWeatherConditionFromJsonResult(JObject result)
        {
            WeatherConditions conditions = new WeatherConditions();
            foreach (var value in result["current"]["values"])
            {
                string propertyName = value.SelectToken("name").ToString();
                float propertyValue = float.Parse(value.SelectToken("value").ToString());
                conditions.GetType().GetProperty(propertyName)?.SetValue(conditions, propertyValue);
            }

            return conditions;
        }
    }
}
