using RunnersWeather.Conditions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RunnersWeather.CurrentConditions
{
    public class ConditionsChecker : IConditionsChecker
    {
        List<ICurrentConditionsProvider> providers = new List<ICurrentConditionsProvider>();

        public async Task<List<WeatherConditions>> GetCurrentConditionsForCoordinates(float lng, float lat)
        {
            if (providers.Count == 0)
                throw new NoProvidersRegistered();

            List<Task<WeatherConditions>> tasks = new List<Task<WeatherConditions>>();

            foreach (var provider in providers)
            {
                tasks.Add(provider.GetCurrentConditionsForCoordinates(lng, lat));
            }

            List<WeatherConditions> conditions = new List<WeatherConditions>();

            foreach(var task in tasks)
            {
                conditions.Add(await task);
            }

            return conditions;
        }

        public void RegisterCurrentConditionProvider(ICurrentConditionsProvider provider)
        {
            providers.Add(provider);
        }
    }

    public class NoProvidersRegistered : Exception
    {

    }
}
