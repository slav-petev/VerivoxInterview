using System;

namespace Verivox.TariffComparison.Core.Tariffs
{
    public class TariffName : IEquatable<TariffName>
    {
        public static readonly TariffName UNKNOWN = new TariffName("Unknown");

        public string Name { get; }

        private TariffName(string name)
        {
            Name = name;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(this, null)) return false;
            if (ReferenceEquals(other, null)) return false;
            if (this.GetType() != other.GetType()) return false;

            return this.Equals((TariffName)other);
        }

        public bool Equals(TariffName other)
        {
            return this.Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public static TariffName Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Tariff Name must be non-empty",
                    nameof(input));

            return new TariffName(input);
        }
    }
}
