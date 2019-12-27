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
    public sealed class HttpClient : IHttpClient
    {
        private readonly System.Net.Http.HttpClient SystemHttpClient = new System.Net.Http.HttpClient();

        private static readonly Lazy<HttpClient> lazy = new Lazy<HttpClient>(() => new HttpClient());

        public static HttpClient Instance { get { return lazy.Value; } }

        private HttpClient()
        {
        }
    

        public void InitWithApiKey(string apiKey)
        {
            Init();
            Instance.SystemHttpClient.DefaultRequestHeaders.Add("apikey", apiKey);
        }
        
        public void Init()
        {
            Instance.SystemHttpClient.DefaultRequestHeaders.Accept.Clear();
            Instance.SystemHttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Instance.SystemHttpClient.DefaultRequestHeaders.Clear();

            CultureInfo.CurrentCulture = new CultureInfo("en-US");
        }

        public async Task<JObject> GetAsync(string url)
        {
            HttpResponseMessage response = await Instance.SystemHttpClient.GetAsync(url);

            string result = await response.Content.ReadAsStringAsync();

            if (IsArray(result))
                result = TrimArrayChars(result);

            return JObject.Parse(result);
        }

        private bool IsArray(string message)
        {
            return message[0] == '[' && message[message.Length - 1] == ']';
        }

        private string TrimArrayChars(string message)
        {
            return message.Substring(1, message.Length - 2);
        }
    }
}
