using NUnit.Framework;
using System;
using Verivox.TariffComparison.Core.Common;

namespace Verivox.TariffComparison.Tests.Core.Common
{
    [TestFixture]
    public class ConsumptionCostTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(-830)]
        [Category("TariffComparison.Core.ConsumptionCost")]
        public void ShouldNotCreateConsumptionCostWithInvalidValue(decimal invalidValue)
        {
            Assert.Throws<ArgumentException>(() =>
                ConsumptionCost.Create(invalidValue));
        }

        [Test]
        [TestCase(830)]
        [Category("TariffComparison.Core.ConsumptionCost")]
        public void ShouldCreateConsumptionCostFromValidValue(decimal value)
        {
            ConsumptionCost cost = ConsumptionCost.Create(value);

            Assert.That(cost, Is.Not.Null);
        }

        [Test]
        [TestCase(830)]
        [Category("TariffComparison.Core.ConsumptionCost")]
        public void CostsWithEqualValueShouldBeEqual(decimal value)
        {
            ConsumptionCost first = ConsumptionCost.Create(value);
            ConsumptionCost second = ConsumptionCost.Create(value);

            Assert.That(first, Is.EqualTo(second));
        }

        [Test]
        [TestCase(830)]
        [Category("TariffComparison.Core.ConsumptionCost")]
        public void CostsWithEqualValueShouldHaveSameHashCode(decimal value)
        {
            ConsumptionCost first = ConsumptionCost.Create(value);
            ConsumptionCost second = ConsumptionCost.Create(value);

            Assert.That(first.GetHashCode(), Is.EqualTo(second.GetHashCode()));
        }

        [Test]
        [TestCase(830, 1000)]
        [Category("TariffComparison.Core.ConsumptionCost")]
        public void CostsWithDifferentValueShouldNotBeEqual(decimal firstValue,
            decimal secondValue)
        {
            ConsumptionCost first = ConsumptionCost.Create(firstValue);
            ConsumptionCost second = ConsumptionCost.Create(secondValue);

            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        [TestCase(830, 1000)]
        [Category("TariffComparison.Core.ConsumptionCost")]
        public void CostsWithDifferentValueShouldHaveDifferentHashCode(
            decimal firstValue, decimal secondValue)
        {
            ConsumptionCost first = ConsumptionCost.Create(firstValue);
            ConsumptionCost second = ConsumptionCost.Create(secondValue);

            Assert.That(first.GetHashCode(), Is.Not.EqualTo(second.GetHashCode()));
        }

        [Test]
        [TestCase(830)]
        [Category("TariffComparison.Core.ConsumptionCost")]
        public void ShouldReturnConsumptionCostAsStringCorrectly(decimal value)
        {
            string expectedValue = $"{value} €";

            ConsumptionCost cost = ConsumptionCost.Create(value);

            Assert.That(expectedValue, Is.EqualTo(cost.ToString()));
        }

        [Test]
        [TestCase(800, 200)]
        [Category("TariffComparison.Core.ConsumptionCost")]
        public void ShouldSumConsumptionCostsCorrectly(decimal firstValue,
            decimal secondValue)
        {
            ConsumptionCost first = ConsumptionCost.Create(firstValue);
            ConsumptionCost second = ConsumptionCost.Create(secondValue);

            ConsumptionCost expectedResult = ConsumptionCost.Create(
                firstValue + secondValue);
            ConsumptionCost actualResult = first + second;

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
    }
}
