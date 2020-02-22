namespace Galytix.Compute
{
    public class ComputationalParameters
    {
        public ComputationalParameters(Range<int> avgGwpYearRange)
        {
            AvgGwpYearRange = avgGwpYearRange;
        }

        public Range<int> AvgGwpYearRange { get; internal set; }
    }
}