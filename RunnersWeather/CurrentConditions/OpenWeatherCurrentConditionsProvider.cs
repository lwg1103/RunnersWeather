using Newtonsoft.Json.Linq;
using RunnersWeather.Conditions;
using RunnersWeather.Http;
using RunnersWeather.Logger;
using System.Threading.Tasks;

namespace RunnersWeather.CurrentConditions
{
    public class OpenWeatherCurrentConditionsProvider : BaseConditionsProvider, ICurrentConditionsProvider
    {
        protected override string Name => "OpenWeather";
        private readonly string APIKey = "1fcb7d183cfcaeb5b72ee5407b766d55";
        private readonly string url = "http://api.openweathermap.org/data/2.5/weather?";

        public OpenWeatherCurrentConditionsProvider(ILogger logger) : base(logger) { }

        protected override async Task<JObject> GetStatusFromAPI(float lng, float lat)
        {
            httpClient.Init();

            return await httpClient.GetAsync($"{url}lat={lat.ToString("F5")}&lon={lng.ToString("F5")}&appid={APIKey}");
        }

        protected override WeatherConditions ParseWeatherConditionFromJsonResult(JObject result)
        {
            WeatherConditions conditions = new WeatherConditions
            {
                TEMPERATURE = result["main"]["feels_like"].Value<float>() - 272.15f, //response in K
                HUMIDITY = result["main"]["humidity"].Value<float>()
            };

            return conditions;
        }
    }
}
