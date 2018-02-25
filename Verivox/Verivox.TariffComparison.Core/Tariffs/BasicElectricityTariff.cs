namespace Verivox.TariffComparison.Core.Tariffs
{
    public class BasicElectricityTariff : Tariff
    {
        private static readonly TariffName _name =
            TariffName.Create("basic electricity tariff");
        public override TariffName Name => _name;
    }
}
