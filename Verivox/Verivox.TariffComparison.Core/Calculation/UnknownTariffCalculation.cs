using Verivox.TariffComparison.Core.Common;

namespace Verivox.TariffComparison.Core.Calculation
{
    public class UnknownTariffCalculation : ITariffCalculation
    {
        public ConsumptionCost Calculate(Consumption consumption)
        {
            return ConsumptionCost.NONE;
        }
    }
}
