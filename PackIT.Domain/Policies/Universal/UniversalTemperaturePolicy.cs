using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace PackIT.Domain.Policies.Universal
{
    internal sealed class UniversalTemperaturePolicy : IPackingItemsPolicy
    {
        private const uint MaximumQuantityOfClothes = 7;

        public bool IsApplicable(PolicyData _)
            => true;

        public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
            => new List<PackingItem>
            {
                new("Toiletry Kit", 1),
                new("Underwear", Math.Min(policyData.Days, MaximumQuantityOfClothes)),
                new("Flip-Flops", 1),
                new("Phone Charger", 1),
                new("Bag Pack", 1)
            };
    }
}