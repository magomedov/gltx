using System;

namespace Galytix.Compute.Interfaces
{
    public interface IRange<T> where T : IComparable<T>
    {
        T From { get; }
        T To { get;  }
        bool IsValid();
    }
}