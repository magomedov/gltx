using System;
using System.Collections.Generic;
using System.Linq;
using Galytix.Data.Interfaces;
using Galytix.Data.Models;
using Galytix.Services.Interfaces;

namespace Galytix.Services
{
    public class GwpService : IGwpService
    {
        private readonly IGwpRecordsProvider _gwpRecordsProvider;
        private List<GwpRecord> _records;

        public GwpService(IGwpRecordsProvider gwpRecordsProvider)
        {
            _gwpRecordsProvider = gwpRecordsProvider;
        }

        public string DoSomething()
        {
            if (_records == null)
                LoadRecords();

            return "something";
        }

        private void LoadRecords()
        {
            _records = _gwpRecordsProvider.GetRecords().ToList();
        }
    }
}
