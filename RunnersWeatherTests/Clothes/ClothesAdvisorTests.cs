using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RunnersWeather.Conditions;
using System.Linq;

namespace RunnersWeather.Clothes.Tests
{
    [TestClass()]
    public class ClothesAdvisorTests
    {
        ClothesAdvisor TestSubject = new ClothesAdvisor();
        [TestMethod()]
        public void SelectRecommendedClothesForConditionsReturnsClothesList()
        {
            var clothes = TestSubject.SelectRecommendedClothesForConditions(new WeatherConditions(), new ClothesContext());
            Assert.IsInstanceOfType(clothes, typeof(List<ClothesPiece>));
        }
        [TestMethod()]
        public void SelectRecommendedClothesForConditionsReturnsClothsThatMatchesConditions()
        {
            var clothes = TestSubject.SelectRecommendedClothesForConditions(GetWeatherConditions(), new ClothesContext());

            foreach (var piece in GetExpectedClothesPieces())
            {
                CollectionAssert.Contains(clothes, piece);
            }
        }
        [TestMethod()]
        public void SelectRecommendedClothesForConditionsReturnsEmptyListIfNothingMatchesConditions()
        {
            var clothes = TestSubject.SelectRecommendedClothesForConditions(new WeatherConditions(), new ClothesContext());
            Assert.AreEqual(0, clothes.Count);
        }

        private WeatherConditions GetWeatherConditions()
        {
            return new WeatherConditions()
            {
                HUMIDITY = 15.0f,
                PM25 = 35.0f,
                TEMPERATURE = 4.0f
            };
        }

        private List<ClothesPiece> GetExpectedClothesPieces()
        {
            var clothes = new ClothesContext().ClothesPiecesDbSet;

            var cap = clothes.Where(c => c.Name == "Czapka Gruba").FirstOrDefault();
            var mask = clothes.Where(c => c.Name == "Maska Antysmogowa").FirstOrDefault();

            return new List<ClothesPiece> { cap, mask };
        }
    }
}