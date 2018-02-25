namespace Verivox.TariffComparison.Core.Common
{
    public class Months
    {
        public static readonly Months YEAR = new Months(12);

        public int Value { get; }

        private Months(int value)
        {
            this.Value = value;
        }
    }
}
