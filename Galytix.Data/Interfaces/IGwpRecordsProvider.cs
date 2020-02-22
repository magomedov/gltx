using System.Collections;
using System.Collections.Generic;
using Galytix.Data.Models;

namespace Galytix.Data.Interfaces
{
    public interface IGwpRecordsProvider
    {
        IEnumerable<GwpRecord> GetRecords();
    }
}