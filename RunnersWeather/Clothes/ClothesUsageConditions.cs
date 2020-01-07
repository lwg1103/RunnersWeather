namespace RunnersWeather.Clothes
{
    public class ClothesUsageConditions
    {
        public int ClothesUsageConditionsId { get; set; }
        public string ParamName { get; set; }
        public float MinValue { get; set; } = float.MinValue;
        public float MaxValue { get; set; } = float.MaxValue;
        public int ClothesPieceId { get; set; }
    }
}
