using RunnersWeather.Conditions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RunnersWeather.CurrentConditions
{
    public interface IConditionsChecker
    {
        Task<List<WeatherConditions>> GetCurrentConditionsForCoordinates(float lng, float lat);
        void RegisterCurrentConditionProvider(ICurrentConditionsProvider provider);
    }
}
