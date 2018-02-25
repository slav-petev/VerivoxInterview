using NUnit.Framework;
using System;
using Verivox.TariffComparison.Core.Tariffs;

namespace Verivox.TariffComparison.Tests.Core.Tariffs
{
    [TestFixture]
    public class TariffNameTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        [Category("TariffComparison.Core.TariffName")]
        public void ShouldNotCreateTariffNameFromInvalidInputString(string invalidName)
        {
            Assert.Throws<ArgumentException>(() => TariffName.Create(invalidName));
        }

        [Test]
        [TestCase("Sample", "Sample")]
        [TestCase("Sample", "sample")]
        [Category("TariffComparison.Core.TariffName")]
        public void TariffNamesWithSameValueShouldBeEqualIgnoreCase(string firstValue,
            string secondValue)
        {
            TariffName firstName = TariffName.Create(firstValue);
            TariffName secondName = TariffName.Create(secondValue);

            Assert.That(firstName, Is.EqualTo(secondName));
        }

        [Test]
        [TestCase("Sample", "Sample")]
        [TestCase("Another", "Another")]
        [Category("TariffComparison.Core.TariffName")]
        public void TariffNamesWithSameValueShouldHaveSameHashCode(string firstValue,
            string secondValue)
        {
            TariffName firstName = TariffName.Create(firstValue);
            TariffName secondName = TariffName.Create(secondValue);

            Assert.That(firstName.GetHashCode(), Is.EqualTo(secondName.GetHashCode()));
        }

        [Test]
        [TestCase("Sample", "Another")]
        [TestCase("Sample1", "Another1")]
        [Category("TariffComparison.Core.TariffName")]
        public void TariffNamesWithDifferentValueShouldNotBeEqual(string firstValue,
            string secondValue)
        {
            TariffName firstName = TariffName.Create(firstValue);
            TariffName secondName = TariffName.Create(secondValue);

            Assert.That(firstName, Is.Not.EqualTo(secondName));
        }

        [Test]
        [TestCase("Sample", "Another")]
        [TestCase("Sample", "sample")]
        [Category("TariffComparison.Core.TariffName")]
        public void TariffNamesWithDifferentValueShouldHaveDifferentHashCode(
            string firstValue, string secondValue)
        {
            TariffName firstName = TariffName.Create(firstValue);
            TariffName secondName = TariffName.Create(secondValue);

            Assert.That(firstName.GetHashCode(), 
                Is.Not.EqualTo(secondName.GetHashCode()));
        }
    }
}
