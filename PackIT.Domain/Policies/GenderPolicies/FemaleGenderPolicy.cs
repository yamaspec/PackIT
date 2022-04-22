using PackIT.Domain.Consts;
using PackIT.Domain.ValueObjects;
using System.Collections.Generic;

namespace PackIT.Domain.Policies.GenderPolicies
{
    internal sealed class FemaleGenderPolicy : IPackingItemsPolicy
    {
        public bool IsApplicable(PolicyData policyData)
            => policyData.Gender is Gender.Female;

        public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
            => new List<PackingItem>
            {
                new("Hair Dryer", 1),
                new("MakeUp Kit", 1),
                new("Bling Kit", 1)
            };
    }
}