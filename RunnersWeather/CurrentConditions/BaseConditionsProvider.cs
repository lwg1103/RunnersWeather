using System.Threading.Tasks;
using RunnersWeather.Conditions;
using Newtonsoft.Json.Linq;
using RunnersWeather.Http;

namespace RunnersWeather.CurrentConditions
{
    public abstract class BaseConditionsProvider : ICurrentConditionsProvider
    {
        private IHttpClient httpClient = Http.HttpClient.Instance;
        public IHttpClient HttpClient
        {
            get => httpClient;
            set { httpClient = value; }
        }

        public async Task<WeatherConditions> GetCurrentConditionsForCoordinates(float lng, float lat)
        {
            JObject result = await GetStatusFromAPI(lng, lat);

            WeatherConditions conditions = ParseWeatherConditionFromJsonResult(result);

            return conditions;
        }

        protected abstract Task<JObject> GetStatusFromAPI(float lng, float lat);
        protected abstract WeatherConditions ParseWeatherConditionFromJsonResult(JObject result);
    }
}
