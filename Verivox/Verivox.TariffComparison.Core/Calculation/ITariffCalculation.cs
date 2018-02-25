using Verivox.TariffComparison.Core.Common;

namespace Verivox.TariffComparison.Core.Calculation
{
    public interface ITariffCalculation
    {
        ConsumptionCost Calculate(Consumption consumption);
    }
}