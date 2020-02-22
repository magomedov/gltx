namespace Galytix.Compute
{
    public struct GrowthRate
    {
        public GrowthRate(int year, decimal rate)
        {
            Year = year;
            Rate = rate;
        }

        public int Year { get; }
        public decimal Rate { get; }
    }
}