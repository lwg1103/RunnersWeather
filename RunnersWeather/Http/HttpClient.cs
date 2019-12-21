using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace RunnersWeather.Http
{
    public class HttpClient
    {
        private readonly System.Net.Http.HttpClient SystemHttpClient = new System.Net.Http.HttpClient();

        private static readonly Lazy<HttpClient> lazy = new Lazy<HttpClient>(() => new HttpClient());

        public static HttpClient Instance { get { return lazy.Value; } }

        private HttpClient()
        {
        }
    

        public void InitWithApiKey(string apiKey)
        {
            Instance.SystemHttpClient.DefaultRequestHeaders.Accept.Clear();
            Instance.SystemHttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            Instance.SystemHttpClient.DefaultRequestHeaders.Add("apikey", apiKey);

            CultureInfo.CurrentCulture = new CultureInfo("en-US");
        }

        public async Task<JObject> GetAsync(string url)
        {
            HttpResponseMessage response = await Instance.SystemHttpClient.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();

            var jsonOptions = new JsonSerializerOptions();
            jsonOptions.MaxDepth = 1;

            return JObject.Parse(result);
        }
    }
}
