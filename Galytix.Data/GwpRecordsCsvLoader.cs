using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Galytix.Data.Interfaces;
using Galytix.Data.Models;

namespace Galytix.Data
{
    public class GwpRecordsCsvLoader : IGwpRecordsProvider
    {
        private readonly string _csvFileName;
        private readonly int _fromYear;

        public GwpRecordsCsvLoader(string csvFileName, int fromYear=2000)
        {
            _csvFileName = csvFileName;
            _fromYear = fromYear;
        }

        public IEnumerable<GwpRecord> GetRecords()
        {
            using (var reader = new StreamReader(_csvFileName)) 
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.MissingFieldFound = null;
                csv.Read();
                csv.ReadHeader();

                var records = new List<GwpRecord>();
                while (csv.Read())
                {
                    var record = new GwpRecord
                    {
                        Country = csv.GetField<string>("country"),
                        Business = csv.GetField<string>("lineOfBusiness"),
                        ValuesPerYear = new Dictionary<int, decimal>()
                    };

                    var currentYear = _fromYear;
                    while (true)
                    {
                        var field = $"Y{currentYear}";
                        var fieldIndex = csv.GetFieldIndex(field);
                        if (fieldIndex == -1)
                            break;
                        
                        var valuePerYear = csv.GetField<decimal?>(fieldIndex);
                        if (valuePerYear != null)
                            record.ValuesPerYear.Add(currentYear, valuePerYear.Value);
                        currentYear++;
                    }

                    records.Add(record);
                }

                return records;
            }
        }
    }
}