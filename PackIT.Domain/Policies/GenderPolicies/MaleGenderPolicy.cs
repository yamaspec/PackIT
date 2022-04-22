using PackIT.Domain.Consts;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace PackIT.Domain.Policies.GenderPolicies
{
    internal sealed class MaleGenderPolicy : IPackingItemsPolicy
    {
        public bool IsApplicable(PolicyData policyData)
            => policyData.Gender is Gender.Male;

        public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
            => new List<PackingItem>
            {
                new("Laptop", 1),
                new("Beer", 10),
                new("Book", (uint) Math.Ceiling(policyData.Days / 7m))
            };
    }
}