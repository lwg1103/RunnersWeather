using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnersWeather.Http
{
    public interface IHttpClient
    {
        void InitWithApiKey(string apiKey);
        void Init();
        Task<JObject> GetAsync(string url);
    }
}
