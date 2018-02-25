using System;
using System.Collections.Generic;

namespace Verivox.TariffComparison.Core.Tariffs.Factory
{
    public class TariffFactory : ITariffFactory
    {
        private static readonly Dictionary<TariffName, Func<Tariff>> _tariffConstructors =
            new Dictionary<TariffName, Func<Tariff>>()
            {
                { TariffName.Create("basic electricity tariff"), () => new BasicElectricityTariff() },
                { TariffName.Create("Packaged tariff"), () => new PackagedTariff() }
            };

        public Tariff Create(TariffName name)
        {
            return _tariffConstructors.ContainsKey(name)
                ? _tariffConstructors[name]()
                : new UnknownTariff();
        }
    }
}
