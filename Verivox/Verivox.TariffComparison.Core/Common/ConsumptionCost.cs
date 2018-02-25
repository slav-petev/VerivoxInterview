using System;

namespace Verivox.TariffComparison.Core.Common
{
    public class ConsumptionCost : IEquatable<ConsumptionCost>, IComparable<ConsumptionCost>
    {
        public static ConsumptionCost NONE = new ConsumptionCost(0);

        public decimal Value { get; }

        private ConsumptionCost(decimal value)
        {
            Value = value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(this, null)) return false;
            if (ReferenceEquals(other, null)) return false;
            if (this.GetType() != other.GetType()) return false;

            return this.Equals((ConsumptionCost)other);
        }

        public bool Equals(ConsumptionCost other)
        {
            return this.Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public int CompareTo(ConsumptionCost other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public override string ToString()
        {
            return $"{this.Value} €";
        }

        public static ConsumptionCost operator +(ConsumptionCost first,
            ConsumptionCost second)
        {
            return Create(first.Value + second.Value);
        }

        public static ConsumptionCost operator *(ConsumptionCost cost,
            Consumption consumption)
        {
            return Create(cost.Value * consumption.Value);
        }
        
        public static ConsumptionCost Create(decimal cost)
        {
            if (cost <= 0)
                throw new ArgumentException("Consumption cost should be positive",
                    nameof(cost));

            return new ConsumptionCost(cost);
        }
    }
}