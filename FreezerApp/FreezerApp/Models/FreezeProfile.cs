namespace FreezerApi.Models
{
    public class FreezeProfile
    {
        public string Tipo { get; set; } = string.Empty;
        public double CostGreaterThanThirty { get; set; }
        public double CostGreaterThanTwenty { get; set; }
        public double CostGreaterThanTen { get; set; }
        public double DefaultCost { get; set; }

    }
}

