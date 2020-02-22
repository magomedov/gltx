using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Galytix.Data.Tests
{
    [TestFixture]
    public class GwpRecordsCsvLoaderTests
    {
        private string GetTestFileName()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "gwpByCountry.csv");
        }

        [Test]
        public void CanLoadDataFromRealCsv()
        {
            var gwpRecordsCsvLoader = new GwpRecordsCsvLoader(GetTestFileName());
            var result = gwpRecordsCsvLoader.GetRecords().ToList();
            Assert.NotNull(result);
            Assert.Greater(result.Count, 0);
        }


        [Test]
        public void StillWorks_When_FromYearGreaterThanCurrentYear_But_ValuesAreEmpty()
        {
            var gwpRecordsCsvLoader = new GwpRecordsCsvLoader(GetTestFileName(),DateTime.Today.Year + 1);
            var result = gwpRecordsCsvLoader.GetRecords().ToList();
            Assert.NotNull(result);
            Assert.Greater(result.Count, 0);
            foreach (var gwpRecord in result)
            {
                Assert.AreEqual(0, gwpRecord.ValuesPerYear.Count);
            }
        }

        [Test]
        public void StillWorks_When_FromYearLessThan2000_But_ValuesAreEmpty()
        {
            var gwpRecordsCsvLoader = new GwpRecordsCsvLoader(GetTestFileName(), DateTime.Today.Year + 1);
            var result = gwpRecordsCsvLoader.GetRecords().ToList();
            Assert.NotNull(result);
            Assert.Greater(result.Count, 0);
            foreach (var gwpRecord in result)
            {
                Assert.AreEqual(0, gwpRecord.ValuesPerYear.Count);
            }
        }
    }
}
