using PackIT.Domain.ValueObjects;
using System.Collections.Generic;

namespace PackIT.Domain.Policies.TemperaturePolicies
{
    internal sealed class TropicTemperaturePolicy : IPackingItemsPolicy
    {
        public bool IsApplicable(PolicyData policyData)
            => policyData.Temperature > 30D;

        public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
            => new List<PackingItem>
            {
                new("Short Pants", 4),
                new("Shirts", 4),
                new("Sneakers", 1),
                new("Straw Hat", 1),
                new("Plastic Raincoat", 1),
                new("Sunnies", 1),
                new("Sunscreen", 1)
            };
    }
}