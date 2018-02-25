using NUnit.Framework;
using Verivox.TariffComparison.Core.Calculation;
using Verivox.TariffComparison.Core.Common;

namespace Verivox.TariffComparison.Tests.Core.Calculation
{
    [TestFixture]
    public class PackagedTariffLowConsumptionCalculationTests
    {
        [Test]
        [TestCase(1000, 800)]
        [TestCase(3500, 800)]
        [TestCase(4000, 800)]
        [Category("TariffComparison.Core.PackagedTariffLowConsumptionCalculation")]
        public void ShouldCalculateYearlyCostCorrectly(int consumptionValue,
            decimal expectedCostValue)
        {
            PackagedTariffLowConsumptionCalculation calculation =
                new PackagedTariffLowConsumptionCalculation();
            Consumption consumption = Consumption.Create(consumptionValue);

            ConsumptionCost expectedCost = ConsumptionCost.Create(
                expectedCostValue);
            ConsumptionCost actualCost = calculation.Calculate(
                consumption);

            Assert.That(expectedCost, Is.EqualTo(actualCost));
        }
    }
}
