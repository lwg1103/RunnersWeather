using RunnersWeather.Conditions;
using RunnersWeather.CurrentConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnersWeather.CurrentConditions
{
    public interface ICurrentConditionsProvider
    {
        Task<WeatherConditions> GetCurrentConditionsForCoordinates(float lng, float lat);
    }
}
