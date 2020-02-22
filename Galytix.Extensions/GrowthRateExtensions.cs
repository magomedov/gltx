using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Galytix.Compute;

namespace Galytix.Extensions
{
    public static class GrowthRateExtensions
    {
        public static decimal Average(this IList<GrowthRate> growthRates)
        {
            if (!growthRates.Any())
                return 0m;
            return growthRates.Select(x => x.Rate).Average();
        }
    }
}