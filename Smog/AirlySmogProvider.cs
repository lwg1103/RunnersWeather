using RunnersWeather.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RunnersWeather.Smog
{
    public class AirlySmogProvider : ISmogProvider
    {
        private ILogger logger;
        private string APIKey = "TcY7Pv87COniLs8ySsanDClgwG3hUTBn";
        HttpClient HttpClient = new HttpClient();

        public AirlySmogProvider(ILogger logger) => this.logger = logger;

        public async Task<string> GetCurrentSmogConditionsForCoordinates(float lng, float lat)
        {
            logger.AddEntry($"checking smog for long: {lng} and lat: {lat}");
            //throw new NotImplementedException();

            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.DefaultRequestHeaders.Add("apikey", APIKey);

            HttpResponseMessage response = await HttpClient.GetAsync($"https://airapi.airly.eu/v2/measurements/point?lat={lat}&lng={lng}");
            string result = await response.Content.ReadAsStringAsync();
            logger.AddEntry(result);

            return result;
        }
    }
}
