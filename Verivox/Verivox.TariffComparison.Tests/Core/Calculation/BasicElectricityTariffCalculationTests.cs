﻿using NUnit.Framework;
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
            decimal expectedCostValue)
        {
            Consumption consumption = Consumption.Create(consumptionValue);
            BasicElectricityTariffCalculation calculation =
                new BasicElectricityTariffCalculation();

            ConsumptionCost expectedCost = ConsumptionCost.Create(expectedCostValue);
            ConsumptionCost actualCost = calculation.Calculate(consumption);

            Assert.That(expectedCost, Is.EqualTo(actualCost));
        }
    }
}
