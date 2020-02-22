using System;
using System.Collections.Generic;
using Galytix.Compute.Interfaces;
using Galytix.Data.Models;

namespace Galytix.Compute
{
    public class GrowthRateCalculator : IGrowthRateCalculator
    {
        public List<GrowthRate> Calculate(GwpRecord record, IRange<int> yearRange)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            if (!yearRange.IsValid())
                throw new ArgumentException($"Year range {yearRange} is invalid");

            var result = new List<GrowthRate>();

            var past = yearRange.From;
            var present = yearRange.From + 1;
            while (present < yearRange.To)
            {
                if (!record.ValuesPerYear.ContainsKey(past))
                {
                    past++;
                    present++;
                    continue;
                }

                if (!record.ValuesPerYear.ContainsKey(present))
                {
                    present++;
                    continue;
                }

                result.Add(new GrowthRate(present, (record.ValuesPerYear[present] - record.ValuesPerYear[past]) /
                                                   record.ValuesPerYear[past]));
                past++;
                present++;
            }

            return result;
        }
    }
}