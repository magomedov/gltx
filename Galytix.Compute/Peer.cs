using System.Collections;
using System.Collections.Generic;

namespace Galytix.Compute
{
    public struct Peer
    {
        public Peer(string country, string businessLine, decimal avgGrowthRate, decimal differenceWithBenchmark)
        {
            Country = country;
            BusinessLine = businessLine;
            AvgGrowthRate = avgGrowthRate;
            DifferenceWithBenchmark = differenceWithBenchmark;
        }

        public decimal AvgGrowthRate { get; }
        public decimal DifferenceWithBenchmark { get; }

        public string Country { get; }
        public string BusinessLine { get; }

        public bool Equals(Peer other)
        {
            return Country == other.Country && BusinessLine == other.BusinessLine;
        }

        public override bool Equals(object obj)
        {
            return obj is Peer other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Country != null ? Country.GetHashCode() : 0) * 397) ^ (BusinessLine != null ? BusinessLine.GetHashCode() : 0);
            }
        }
    }

    public class PeerComparer : IComparer<Peer>
    {
        public int Compare(Peer x, Peer y)
        {
            return x.DifferenceWithBenchmark.CompareTo(y.DifferenceWithBenchmark);
        }
    }
}