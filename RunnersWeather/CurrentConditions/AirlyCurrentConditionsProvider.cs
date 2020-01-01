using Newtonsoft.Json.Linq;
using RunnersWeather.Conditions;
using System.Threading.Tasks;
using System.Configuration;

namespace RunnersWeather.CurrentConditions
{
    public class AirlyCurrentConditionsProvider : BaseConditionsProvider, ICurrentConditionsProvider
    {
        private readonly string APIKey = ConfigurationManager.AppSettings["AirlyApiKey"];
        private readonly string airlyUrl = "https://airapi.airly.eu/v2/measurements/point?";

        protected override async Task<JObject> GetStatusFromAPI(float lng, float lat)
        {
            HttpClient.InitWithApiKey(APIKey);

            return await HttpClient.GetAsync($"{airlyUrl}lat={lat.ToString("F5")}&lng={lng.ToString("F5")}");
        }

        protected override WeatherConditions ParseWeatherConditionFromJsonResult(JObject result)
        {
            WeatherConditions conditions = new WeatherConditions() { Provider = "Airly" };
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
