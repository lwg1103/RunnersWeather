using Newtonsoft.Json.Linq;
using RunnersWeather.Conditions;
using RunnersWeather.Logger;
using System.Threading.Tasks;

namespace RunnersWeather.CurrentConditions
{
    public class AirlyCurrentConditionsProvider : BaseConditionsProvider, ICurrentConditionsProvider
    {
        protected override string Name => "Airly";
        private readonly string APIKey = "TcY7Pv87COniLs8ySsanDClgwG3hUTBn";
        private readonly string airlyUrl = "https://airapi.airly.eu/v2/measurements/point?";

        public AirlyCurrentConditionsProvider(ILogger logger) : base(logger) { }

        protected override async Task<JObject> GetStatusFromAPI(float lng, float lat)
        {
            HttpClient.InitWithApiKey(APIKey);

            return await HttpClient.GetAsync($"{airlyUrl}lat={lat.ToString("F5")}&lng={lng.ToString("F5")}");
        }

        protected override WeatherConditions ParseWeatherConditionFromJsonResult(JObject result)
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
