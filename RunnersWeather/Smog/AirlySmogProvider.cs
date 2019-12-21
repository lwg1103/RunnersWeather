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

        public async Task<string> GetCurrentSmogConditionsForCoordinates(float lng, float lat)
        {
            logger.AddEntry($"Checking smog and weather for long: {lng} and lat: {lat} on Airly");
            var httpClient = Http.HttpClient.Instance;

            httpClient.InitWithApiKey(APIKey);

            JObject result = await httpClient.GetAsync($"{airlyUrl}lat={lat.ToString("F5")}&lng={lng.ToString("F5")}");

            WeatherConditions conditions = new WeatherConditions();
            foreach (var value in result["current"]["values"])
            {

            }

            logger.AddEntry(result["current"]["values"].ToString());

            return result.ToString();
        }
    }
}
