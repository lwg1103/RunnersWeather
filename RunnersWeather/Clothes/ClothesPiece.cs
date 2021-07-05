using System.Collections.Generic;

namespace RunnersWeather.Clothes
{
    public class ClothesPiece
    {
        public int ClothesPieceId { get; set; }
        public string Name { get; set; }
        public virtual List<ClothesUsageConditions> UsageConditions { get; set; } = new List<ClothesUsageConditions>();
    }
}
