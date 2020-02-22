using System.Collections.Generic;
using Galytix.Compute;
using Galytix.Compute.Interfaces;
using Galytix.Data.Interfaces;
using Galytix.Data.Models;
using Moq;
using NUnit.Framework;

namespace Galytix.Services.Tests
{
    [TestFixture]
    public class GwpServiceTests
    {
        [Test]
        //Need to add real tests here 
        public void SomeDummyTest()
        {
            var mockRecordsProvider = new Mock<IGwpRecordsProvider>();
            mockRecordsProvider.Setup(x => x.GetRecords()).Returns(new List<GwpRecord>()
            {
                new GwpRecord
                {
                    Business = "lb", Country = "ae",
                    ValuesPerYear = new Dictionary<int, decimal> {{2000, 100m}, {2001, 102m}}
                },
                new GwpRecord
                {
                    Business = "bl", Country = "ae",
                    ValuesPerYear = new Dictionary<int, decimal> {{2000, 100m}, {2001, 102m}}
                }
            });

            var mockGrowthRateCalculator = new Mock<IGrowthRateCalculator>();

            mockGrowthRateCalculator.Setup(x => x.Calculate(It.IsAny<GwpRecord>(), It.IsAny<IRange<int>>()))
                .Returns(new List<GrowthRate>() {new GrowthRate(2001, 0.4m)});

            var mockParametersProvider = new Mock<IComputationalParametersProvider>();
            mockParametersProvider.Setup(x => x.GetParameters())
                .Returns(new ComputationalParameters(new Range<int>(2008, 2015)));

            var service = new GwpService(mockRecordsProvider.Object, mockGrowthRateCalculator.Object,
                mockParametersProvider.Object);

            service.GetPeers("ae", "lb", 1);
        }

    }
}
