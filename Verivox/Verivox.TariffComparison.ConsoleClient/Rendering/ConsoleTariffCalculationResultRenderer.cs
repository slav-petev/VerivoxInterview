using System;
using System.Linq;
using Verivox.TariffComparison.Core.Collections;
using Verivox.TariffComparison.Core.Collections.Rendering;

namespace Verivox.TariffComparison.ConsoleClient.Rendering
{
    public class ConsoleTariffCalculationResultRenderer :
        ITariffCalculationResultRenderer
    {
        public void Render(TariffCalculationResultCollection collection)
        {
            foreach (var element in collection)
            {
                string tariffName = element.Key.Name;
                string elementValues = string.Join(", ", 
                    element.Value.Select(value => value.Value));
                Console.WriteLine($"{tariffName} -> {elementValues}");
            }
        }
    }
}
