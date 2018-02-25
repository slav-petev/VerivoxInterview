using System;
using System.Linq;
using Verivox.TariffComparison.ConsoleClient.Extensions;
using Verivox.TariffComparison.ConsoleClient.Rendering;
using Verivox.TariffComparison.Core.Calculation;
using Verivox.TariffComparison.Core.Calculation.Factory;
using Verivox.TariffComparison.Core.Collections;
using Verivox.TariffComparison.Core.Common;
using Verivox.TariffComparison.Core.Tariffs;
using Verivox.TariffComparison.Core.Tariffs.Factory;

namespace Verivox.TariffComparison.ConsoleClient
{
    public class TariffComparisonSolution
    {
        static void Main(string[] args)
        {
            ITariffFactory tariffFactory = new TariffFactory();
            ITariffCalculationFactory calculationFactory =
                new TariffCalculationFactory();

            Tariff[] tariffs = Console.ReadLine()
                .Split(',')
                .Select(TariffName.Create)
                .Select(tariffFactory.Create)
                .ToArray();
            Consumption[] consumptions = Console.ReadLine()
                .Split(',')
                .Select(value => value.ToConsumption())
                .ToArray();

            TariffCalculationResultCollection resultCollection =
                new TariffCalculationResultCollection();
            foreach (Tariff tariff in tariffs)
            {
                foreach (Consumption consumption in consumptions)
                {
                    ITariffCalculation calculation = calculationFactory
                        .Create(tariff, consumption);
                    ConsumptionCost tariffCost = tariff.Calculate(
                        consumption, calculation);
                    resultCollection.Add(tariff.Name, tariffCost);
                }
            }

            resultCollection.Render(new ConsoleTariffCalculationResultRenderer());
        }
    }
}
