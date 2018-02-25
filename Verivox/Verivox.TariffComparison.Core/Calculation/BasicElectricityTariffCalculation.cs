using Verivox.TariffComparison.Core.Common;
using Verivox.TariffComparison.Core.Extensions;

namespace Verivox.TariffComparison.Core.Calculation
{
    public class BasicElectricityTariffCalculation : ITariffCalculation
    {
        private static readonly ConsumptionCost _baseCost =
            ConsumptionCost.Create(5);
        private static readonly ConsumptionCost _additionalCost =
            ConsumptionCost.Create(0.22M);

        public ConsumptionCost Calculate(Consumption consumption)
        {
            ConsumptionCost yearlyBaseCost = _baseCost.Yearly();
            ConsumptionCost additionalCost =
                _additionalCost * consumption;

            return yearlyBaseCost + additionalCost;
        }
    }
}