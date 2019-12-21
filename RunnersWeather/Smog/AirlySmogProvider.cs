using Newtonsoft.Json.Linq;
using RunnersWeather.Conditions;
using RunnersWeather.Logger;
using System.Threading.Tasks;

namespace RunnersWeather.Smog
{
    public class AirlySmogProvider : ISmogProvider
    {
        private ILogger logger;
        private string APIKey = "TcY7Pv87COniLs8ySsanDClgwG3hUTBn";
        private string airlyUrl = "https://airapi.airly.eu/v2/measurements/point?";

        public AirlySmogProvider(ILogger logger) => this.logger = logger;

        public async Task<WeatherConditions> GetCurrentSmogConditionsForCoordinates(float lng, float lat)
        {
            printStartInfo(lng, lat);

            JObject result = await getStatusFromAirly(lng, lat);

            WeatherConditions conditions = parseWeatherConditionFromJsonResult(result);

            printConditionsInfo(conditions);
            
            return conditions;
        }

        private void printConditionsInfo(WeatherConditions conditions)
        {
            logger.AddEntry($"PM25: {conditions.PM25}");
            logger.AddEntry($"PM10: {conditions.PM10}");
            logger.AddEntry($"TEMPERATURE: {conditions.TEMPERATURE}");
            logger.AddEntry($"HUMIDITY: {conditions.HUMIDITY}");
        }

        private async Task<JObject> getStatusFromAirly(float lng, float lat)
        {
            var httpClient = Http.HttpClient.Instance;
            httpClient.InitWithApiKey(APIKey);
            JObject result = await httpClient.GetAsync($"{airlyUrl}lat={lat.ToString("F5")}&lng={lng.ToString("F5")}");
            return result;
        }

        private void printStartInfo(float lng, float lat)
        {
            logger.AddEntry($"Checking smog and weather for long: {lng} and lat: {lat} on Airly");
        }

        private static WeatherConditions parseWeatherConditionFromJsonResult(JObject result)
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
