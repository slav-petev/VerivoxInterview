using System.Collections;
using System.Collections.Generic;
using Verivox.TariffComparison.Core.Collections.Rendering;
using Verivox.TariffComparison.Core.Common;
using Verivox.TariffComparison.Core.Tariffs;

namespace Verivox.TariffComparison.Core.Collections
{
    public class TariffCalculationResultCollection : 
        IEnumerable<KeyValuePair<TariffName, SortedSet<ConsumptionCost>>>
    {
        private readonly Dictionary<TariffName, SortedSet<ConsumptionCost>>
            _innerCollection = new Dictionary<TariffName, SortedSet<ConsumptionCost>>();

        public void Add(TariffName name, ConsumptionCost calculatedCost)
        {
            if (name.Equals(TariffName.UNKNOWN)) return;

            if (_innerCollection.ContainsKey(name))
                _innerCollection[name].Add(calculatedCost);
            else
                _innerCollection.Add(name, new SortedSet<ConsumptionCost>(
                    new[] { calculatedCost }));
        }

        public void Render(ITariffCalculationResultRenderer renderer)
        {
            renderer.Render(this);
        }

        public IEnumerator<KeyValuePair<TariffName, SortedSet<ConsumptionCost>>> GetEnumerator()
        {
            return _innerCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
