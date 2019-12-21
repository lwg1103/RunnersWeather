using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnersWeather.Smog
{
    public interface ISmogProvider
    {
        Task<string> GetCurrentSmogConditionsForCoordinates(float lng, float lat);
    }
}
