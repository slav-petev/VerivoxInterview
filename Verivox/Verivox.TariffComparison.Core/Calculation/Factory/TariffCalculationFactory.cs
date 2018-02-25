using System;
using System.Collections.Generic;
using Verivox.TariffComparison.Core.Common;
using Verivox.TariffComparison.Core.Tariffs;

namespace Verivox.TariffComparison.Core.Calculation.Factory
{
    public class TariffCalculationFactory : ITariffCalculationFactory
    {
        private static readonly Dictionary<Tariff, Func<Consumption, ITariffCalculation>> _calculations =
            new Dictionary<Tariff, Func<Consumption, ITariffCalculation>>
            {
                { new BasicElectricityTariff(), (consumption) => new BasicElectricityTariffCalculation() },
                { new PackagedTariff(), (consumption) => GetPackagedTariffCalculation(consumption)}
            };

        public ITariffCalculation Create(Tariff tariff, 
            Consumption consumption)
        {
            return _calculations.ContainsKey(tariff)
                ? _calculations[tariff](consumption)
                : new UnknownTariffCalculation();
        }

        private static ITariffCalculation GetPackagedTariffCalculation(
            Consumption consumption)
        {
            return consumption.Value <= 4000
                ? (ITariffCalculation)new PackagedTariffLowConsumptionCalculation()
                : (ITariffCalculation)new PackagedTariffHighConsumptionCalculation();
        }
    }
}
