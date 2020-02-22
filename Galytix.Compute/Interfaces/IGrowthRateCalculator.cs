using System.Collections.Generic;
using Galytix.Data.Models;

namespace Galytix.Compute.Interfaces
{
    public interface IGrowthRateCalculator
    {
        List<GrowthRate> Calculate(GwpRecord record, IRange<int> yearRange);
    }
}