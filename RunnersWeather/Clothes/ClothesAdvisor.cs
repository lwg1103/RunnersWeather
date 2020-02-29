using RunnersWeather.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnersWeather.Clothes
{
    public class ClothesAdvisor : IClothesAdvisor
    {
        public List<ClothesPiece> SelectRecommendedClothesForConditions(WeatherConditions conditions, ClothesContext context)
        {
            var result = new List<ClothesPiece>();

            return result;
        }
    }
}
