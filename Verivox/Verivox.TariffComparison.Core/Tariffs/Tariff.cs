using Verivox.TariffComparison.Core.Calculation;
using Verivox.TariffComparison.Core.Common;

namespace Verivox.TariffComparison.Core.Tariffs
{
    public abstract class Tariff
    {
        public abstract TariffName Name { get; }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(this, null)) return false;
            if (ReferenceEquals(other, null)) return false;
            if (this.GetType() != other.GetType()) return false;

            Tariff otherTariff = (Tariff)other;
            return this.Name.Equals(otherTariff.Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public ConsumptionCost Calculate(Consumption consumption,
            ITariffCalculation calculation)
        {
            return calculation.Calculate(consumption);
        }
    }
}
