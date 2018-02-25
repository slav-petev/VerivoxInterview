using Verivox.TariffComparison.Core.Common;

namespace Verivox.TariffComparison.Core.Calculation
{
    public class PackagedTariffLowConsumptionCalculation : ITariffCalculation
    {
        private static readonly ConsumptionCost _baseCost =
            ConsumptionCost.Create(800);

        public ConsumptionCost Calculate(Consumption consumption)
        {
            return _baseCost;
        }
    }
}