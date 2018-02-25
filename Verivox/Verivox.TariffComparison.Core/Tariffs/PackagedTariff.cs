namespace Verivox.TariffComparison.Core.Tariffs
{
    public class PackagedTariff : Tariff
    {
        private static readonly TariffName _name =
            TariffName.Create("Packaged tariff");
        public override TariffName Name => _name;
    }
}
