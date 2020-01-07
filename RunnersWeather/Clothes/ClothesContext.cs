
using System.Data.Entity;

namespace RunnersWeather.Clothes
{
    public class ClothesContext : DbContext
    {
        public DbSet<ClothesPiece> ClothesPiecesDbSet { get; set; }
        public DbSet<ClothesUsageConditions> ClothesUsageConditionsDbSet { get; set; }

    }

    public static class CLothesFixtures
    {
        public static void Load()
        {
            var db = new ClothesContext();

            var cap1 = new ClothesPiece() { Name = "Czapka" };
            var temp10 = new ClothesUsageConditions() { ParamName = "Temp", MaxValue = 10.0f };
            cap1.UsageConditions.Add(temp10);

            var cap2 = new ClothesPiece() { Name = "Czapka Gruba" };
            var temp5 = new ClothesUsageConditions() { ParamName = "Temp", MaxValue = 5.0f };
            cap2.UsageConditions.Add(temp5);

            var mask = new ClothesPiece() { Name = "Maska Antysmogowa" };
            var temp10_2 = new ClothesUsageConditions() { ParamName = "Temp", MaxValue = 10.0f };
            var pm25 = new ClothesUsageConditions() { ParamName = "PM25", MinValue = 25.0f };
            mask.UsageConditions.Add(temp10_2);
            mask.UsageConditions.Add(pm25);

            db.ClothesPiecesDbSet.Add(cap1);
            db.ClothesPiecesDbSet.Add(cap2);
            db.ClothesPiecesDbSet.Add(mask);

            db.SaveChanges();
        }
    }
}
