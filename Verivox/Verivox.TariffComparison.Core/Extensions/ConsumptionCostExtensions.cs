using Verivox.TariffComparison.Core.Common;

namespace Verivox.TariffComparison.Core.Extensions
{
    public static class ConsumptionCostExtensions
    {
        public static ConsumptionCost Yearly(this ConsumptionCost cost)
        {
            return ConsumptionCost.Create(cost.Value * Months.YEAR.Value);
        }
    }
}
