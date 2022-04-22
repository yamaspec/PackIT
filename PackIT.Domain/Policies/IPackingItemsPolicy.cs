using PackIT.Domain.ValueObjects;
using System.Collections.Generic;

namespace PackIT.Domain.Policies
{
    public interface IPackingItemsPolicy
    {
        bool IsApplicable(PolicyData policyData);

        IEnumerable<PackingItem> GenerateItems(PolicyData policyData);
    }
}