using NUnit.Framework;
using System;
using Verivox.TariffComparison.Core.Common;

namespace Verivox.TariffComparison.Tests.Core.Common
{
    [TestFixture]
    public class ConsumptionTests
    {
        [Test]
        [TestCase(int.MinValue)]
        [TestCase(0)]
        [Category("TariffComparison.Core.Consumption")]
        public void ShouldNotCreateConsumptionForInvalidValue(int invalidValue)
        {
            Assert.Throws<ArgumentException>(() =>
                Consumption.Create(invalidValue));
        }

        [Test]
        [TestCase(int.MaxValue)]
        [TestCase(3500)]
        [Category("TariffComparison.Core.Consumption")]
        public void ShouldCreateConsumptionForValidValue(int validValue)
        {
            Consumption consumption = Consumption.Create(validValue);

            Assert.That(consumption, Is.Not.Null);
        }

        [Test]
        [TestCase(3500)]
        [Category("TariffComparison.Core.Consumption")]
        public void ConsumptionsWithEqualValueShouldBeEqual(int value)
        {
            Consumption first = Consumption.Create(value);
            Consumption second = Consumption.Create(value);

            Assert.That(first, Is.EqualTo(second));
        }

        [Test]
        [TestCase(3500)]
        [Category("TariffComparison.Core.Consumption")]
        public void ConsumptionsWithEqualValueShouldHaveEqualHashCode(int value)
        {
            Consumption first = Consumption.Create(value);
            Consumption second = Consumption.Create(value);

            Assert.That(first.GetHashCode(), Is.EqualTo(
                second.GetHashCode()));
        }

        [Test]
        [TestCase(3500, 4000)]
        [Category("TariffComparison.Core.Consumption")]
        public void ConsumptionWithDifferentValueShouldNotBeEqual(int firstValue,
            int secondValue)
        {
            Consumption first = Consumption.Create(firstValue);
            Consumption second = Consumption.Create(secondValue);

            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        [TestCase(3500, 4000)]
        [Category("TariffComparison.Core.Consumption")]
        public void ConsumptionsWithDifferentValueShouldHaveDifferentHashCode(
            int firstValue, int secondValue)
        {
            Consumption first = Consumption.Create(firstValue);
            Consumption second = Consumption.Create(secondValue);

            Assert.That(first.GetHashCode(), Is.Not.EqualTo(
                second.GetHashCode()));
        }

        [Test]
        [TestCase(4000, 3500, 500)]
        [TestCase(1000, 2000, 1000)]
        [Category("TariffComparison.Core.Consumption")]
        public void ShouldSubtractConsumptionsCorrectly(int firstValue,
            int secondValue, int expectedValue)
        {
            Consumption first = Consumption.Create(firstValue);
            Consumption second = Consumption.Create(secondValue);

            Consumption expected = Consumption.Create(expectedValue);
            Consumption actual = first - second;

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        [Category("TariffComparison.Core.Consumption")]
        public void ShouldReturnZeroConsumptionWhenSubtractingEqualConsumptions()
        {
            const int consumptionValue = 1000;

            Consumption first = Consumption.Create(consumptionValue);
            Consumption second = Consumption.Create(consumptionValue);

            Consumption expected = Consumption.ZERO;
            Consumption actual = first - second;

            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}
