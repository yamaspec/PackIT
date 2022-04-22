using PackIT.Domain.ValueObjects;
using System.Collections.Generic;

namespace PackIT.Domain.Policies.TemperaturePolicies
{
    internal sealed class PolarTemperaturePolicy : IPackingItemsPolicy
    {
        public bool IsApplicable(PolicyData policyData)
            => policyData.Temperature < 7D;

        public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
            => new List<PackingItem>
            {
                new("Polar Fleece Jacket", 1),
                new("Thermal Suit", 1),
                new("Snow boots", 1),
                new("Fur Hat", 1),
                new("Gloves", 1)
            };
    }
}