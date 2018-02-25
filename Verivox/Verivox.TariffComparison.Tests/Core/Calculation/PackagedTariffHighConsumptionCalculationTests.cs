using NUnit.Framework;
using Verivox.TariffComparison.Core.Calculation;
using Verivox.TariffComparison.Core.Common;

namespace Verivox.TariffComparison.Tests.Core.Calculation
{
    [TestFixture]
    public class PackagedTariffHighConsumptionCalculationTests
    {
        [Test]
        [TestCase(4500, 950)]
        [TestCase(6000, 1400)]
        [Category("TariffComparison.Core.PackagedTariffHighConsumptionCalculation")]
        public void ShouldCalculateYearlyCostsCorrectly(int consumptionValue,
            decimal expectedCostValue)
        {
            PackagedTariffHighConsumptionCalculation calculation =
                new PackagedTariffHighConsumptionCalculation();

            ConsumptionCost expectedCost = ConsumptionCost.Create(expectedCostValue);
            Consumption consumption = Consumption.Create(consumptionValue);
            ConsumptionCost actualCost = calculation.Calculate(consumption);

            Assert.That(expectedCost, Is.EqualTo(actualCost));
        }
    }
}
