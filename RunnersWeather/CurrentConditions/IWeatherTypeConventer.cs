using RunnersWeather.Conditions;

namespace RunnersWeather.CurrentConditions
{
    interface IWeatherTypeConventer
    {
        WeatherType ConvertFromProviderFormat(object source); 
    }
}
