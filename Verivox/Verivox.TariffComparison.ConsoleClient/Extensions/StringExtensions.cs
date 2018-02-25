using System;
using Verivox.TariffComparison.Core.Common;

namespace Verivox.TariffComparison.ConsoleClient.Extensions
{
    public static class StringExtensions
    {
        public static Consumption ToConsumption(this string input)
        {
            if (!int.TryParse(input, out int consumptionValue))
                throw new ArgumentException("Invalid format for consumption",
                    nameof(input));
            
            return Consumption.Create(consumptionValue);
        }
    }
}
