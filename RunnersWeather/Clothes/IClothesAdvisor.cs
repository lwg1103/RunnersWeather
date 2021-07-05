using System.Collections.Generic;
using RunnersWeather.Conditions;

namespace RunnersWeather.Clothes
{
    public interface IClothesAdvisor
    {
        List<ClothesPiece> SelectRecommendedClothesForConditions(WeatherConditions conditions, ClothesContext context);
    }
}
