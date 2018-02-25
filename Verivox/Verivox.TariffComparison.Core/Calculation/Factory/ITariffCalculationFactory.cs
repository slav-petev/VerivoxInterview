using Verivox.TariffComparison.Core.Common;
using Verivox.TariffComparison.Core.Tariffs;

namespace Verivox.TariffComparison.Core.Calculation.Factory
{
    public interface ITariffCalculationFactory
    {
        ITariffCalculation Create(Tariff tariff, Consumption consumption);
    }
}