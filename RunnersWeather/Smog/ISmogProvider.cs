using RunnersWeather.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnersWeather.Smog
{
    public interface ISmogProvider
    {
        Task<WeatherConditions> GetCurrentSmogConditionsForCoordinates(float lng, float lat);
    }
}
