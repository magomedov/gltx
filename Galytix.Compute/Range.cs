using System;
using Galytix.Compute.Interfaces;

namespace Galytix.Compute
{
    public class Range<T> : IRange<T> where T : IComparable<T>
    {
        public Range(T @from, T to)
        {
            From = @from;
            To = to;
        }

        public T From { get; }
        public T To { get; }
        public bool IsValid()
        {
            return From.CompareTo(To) <= 0;
        }

        public override string ToString()
        {
            return $"[{From}-{To}]";
        }
    }
}