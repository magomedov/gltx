using System.Collections.Generic;
using System.Linq;
using Galytix.Compute;
using Galytix.Compute.Interfaces;
using Galytix.Data.Interfaces;
using Galytix.Data.Models;
using Galytix.Extensions;
using Galytix.Services.Interfaces;

namespace Galytix.Services
{
    public class GwpService : IGwpService
    {
        private readonly IGwpRecordsProvider _gwpRecordsProvider;
        private readonly IGrowthRateCalculator _growthRateCalculator;
        private readonly ComputationalParameters _computationalParameters;
        private List<GwpRecord> _records;


        public GwpService(IGwpRecordsProvider gwpRecordsProvider, IGrowthRateCalculator growthRateCalculator, IComputationalParametersProvider computationalParametersProvider)
        {
            _gwpRecordsProvider = gwpRecordsProvider;
            _growthRateCalculator = growthRateCalculator;
            _computationalParameters = computationalParametersProvider.GetParameters();
        }

        public string GetPeers()
        {
            return "something";
        }

        private void LoadRecords()
        {
            _records = _gwpRecordsProvider.GetRecords().ToList();
        }

        public List<Peer> GetPeers(string countryCode, string lineOfBusiness, int numberOfPeers)
        {
            if (_records == null)
                LoadRecords();

            var peers = new List<Peer>();
            
            var benchMarkRecord = _records.AsQueryable()
                .WhereIf(countryCode != null, x => x.Country == countryCode)
                .WhereIf(lineOfBusiness != null, x => x.Business == lineOfBusiness).SingleOrDefault();

            var benchMark =_growthRateCalculator.Calculate(benchMarkRecord, _computationalParameters.AvgGwpYearRange).Average();

            foreach (var record in _records)
            {
                if (record.Country == countryCode && record.Business == lineOfBusiness)
                    continue;

                var growthRates = _growthRateCalculator.Calculate(record, _computationalParameters.AvgGwpYearRange);
                var average = growthRates.Average();
                
                peers.Add(new Peer(record.Country, record.Business, average, average-benchMark));
            }

            peers.Sort(new PeerComparer());

            return peers.Take(numberOfPeers).ToList();
        }
    }
}
