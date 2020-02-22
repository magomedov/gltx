using System;
using System.Collections.Generic;

namespace Galytix.Data.Models
{
    public class GwpRecord
    {
        public string Country { get; set; }
        public string Business { get; set; }
        public Dictionary<int, decimal> ValuesPerYear { get; set; }
    }
}
