﻿using System;

namespace Verivox.TariffComparison.Core.Core.Common
{
    public class Consumption : IEquatable<Consumption>
    {
        public int Value { get; }

        private Consumption(int value)
        {
            Value = value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(this, null)) return false;
            if (ReferenceEquals(other, null)) return false;
            if (this.GetType() != other.GetType()) return false;

            return this.Equals((Consumption)other);
        }

        public bool Equals(Consumption other)
        {
            return this.Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public static Consumption Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Consumption must have positive value",
                    nameof(value));

            return new Consumption(value);
        }
    }
}