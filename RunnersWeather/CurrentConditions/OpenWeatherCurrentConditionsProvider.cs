using Newtonsoft.Json.Linq;
using RunnersWeather.Conditions;
using RunnersWeather.Logger;
using System.Threading.Tasks;
using System.Configuration;

namespace RunnersWeather.CurrentConditions
{
    public class OpenWeatherCurrentConditionsProvider : BaseConditionsProvider, ICurrentConditionsProvider
    {
        protected override string Name => "OpenWeather";
        private readonly string APIKey = ConfigurationManager.AppSettings["OpenWeatherApiKey"];
        private readonly string url = "http://api.openweathermap.org/data/2.5/weather?";

        public OpenWeatherCurrentConditionsProvider(ILogger logger) : base(logger) { }

        protected override async Task<JObject> GetStatusFromAPI(float lng, float lat)
        {
            HttpClient.Init();

            return await HttpClient.GetAsync($"{url}lat={lat.ToString("F5")}&lon={lng.ToString("F5")}&appid={APIKey}");
        }

        protected override WeatherConditions ParseWeatherConditionFromJsonResult(JObject result)
        {
            WeatherConditions conditions = new WeatherConditions
            {
                //PM10 = null,
                //PM25 = null,
                TEMPERATURE = result["main"]["feels_like"].Value<float>() - 272.15f, //response in K
                HUMIDITY = result["main"]["humidity"].Value<float>()
            };

            return conditions;
        }
    }
}
