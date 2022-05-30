namespace CenedQualificando.Domain.Models.ValueObjects
{
    public class DecimalRange
    {
        public decimal? Start { get; set; } = decimal.MinValue;
        public decimal? End { get; set; } = decimal.MaxValue;
    }
}
