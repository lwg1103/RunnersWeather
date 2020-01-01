using Newtonsoft.Json.Linq;
using RunnersWeather.Conditions;
using System.Threading.Tasks;
using System.Configuration;

namespace RunnersWeather.CurrentConditions
{
    public class OpenWeatherCurrentConditionsProvider : BaseConditionsProvider, ICurrentConditionsProvider
    {
        private readonly string APIKey = ConfigurationManager.AppSettings["OpenWeatherApiKey"];
        private readonly string url = "http://api.openweathermap.org/data/2.5/weather?";

        protected override async Task<JObject> GetStatusFromAPI(float lng, float lat)
        {
            HttpClient.Init();

            return await HttpClient.GetAsync($"{url}lat={lat.ToString("F5")}&lon={lng.ToString("F5")}&appid={APIKey}");
        }

        protected override WeatherConditions ParseWeatherConditionFromJsonResult(JObject result)
        {
            WeatherConditions conditions = new WeatherConditions
            {
                Provider = "OpenWeather",
                TEMPERATURE = result["main"]["feels_like"].Value<float>() - 272.15f, //response in K
                HUMIDITY = result["main"]["humidity"].Value<float>(),
                WIND = result["wind"]["speed"].Value<float>()
            };

            return conditions;
        }
    }
}
