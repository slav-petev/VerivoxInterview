using Verivox.TariffComparison.Core.Common;

namespace Verivox.TariffComparison.Core.Calculation
{
    public class PackagedTariffHighConsumptionCalculation : ITariffCalculation
    {
        private static readonly Consumption _lowerConsumptionBoundary =
            Consumption.Create(4000);
        private static readonly ConsumptionCost _baseCost =
            ConsumptionCost.Create(800);
        private static readonly ConsumptionCost _additionalCost =
            ConsumptionCost.Create(0.3M);

        public ConsumptionCost Calculate(Consumption consumption)
        {
            Consumption delta = consumption - _lowerConsumptionBoundary;

            ConsumptionCost additionConsumptionCost = _additionalCost * delta;

            return _baseCost + additionConsumptionCost;
        }
    }
}