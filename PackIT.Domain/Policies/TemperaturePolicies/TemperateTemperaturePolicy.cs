using PackIT.Domain.ValueObjects;
using System.Collections.Generic;

namespace PackIT.Domain.Policies.TemperaturePolicies
{
    internal sealed class TemperateTemperaturePolicy : IPackingItemsPolicy
    {
        public bool IsApplicable(PolicyData policyData)
            => policyData.Temperature.Value is > 6D and < 31D;

        public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
            => new List<PackingItem>
            {
                new("Short Pants", 2),
                new("Long Pants", 2),
                new("Jumper", 1),
                new("TShirt", 3),
                new("Head Cap", 1)
            };
    }
}