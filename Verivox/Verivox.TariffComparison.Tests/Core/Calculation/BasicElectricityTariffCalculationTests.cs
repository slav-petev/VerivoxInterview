using NUnit.Framework;
using Verivox.TariffComparison.Core.Calculation;
using Verivox.TariffComparison.Core.Common;

namespace Verivox.TariffComparison.Tests.Core.Calculation
{
    [TestFixture]
    public class BasicElectricityTariffCalculationTests
    {
        [Test]
        [TestCase(3500, 830)]
        [TestCase(4500, 1050)]
        [TestCase(6000, 1380)]
        [Category("TariffComparison.Core.BasicElectricityTariffCalculation")]
        public void ShouldCalculateYearlyCostCorrectly(int consumptionValue,
            decimal expectedCost)
        {
            Consumption consumption = Consumption.Create(consumptionValue);
            BasicElectricityTariffCalculation calculation =
                new BasicElectricityTariffCalculation();

            ConsumptionCost cost = calculation.Calculate(consumption);

            Assert.That(expectedCost, Is.EqualTo(cost.Value));
        }
    }
}
