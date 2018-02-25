namespace Verivox.TariffComparison.Core.Tariffs.Factory
{
    public interface ITariffFactory
    {
        Tariff Create(TariffName name);
    }
}