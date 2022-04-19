using PackIT.Domain.Consts;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Factories
{
    public class PackingListFactory : IPackingListFactory
    {
        public PackingList Create(PackingListId id, PackingListName name, Localization localization)
        {
            throw new System.NotImplementedException();
        }

        public PackingList CreateWithDefaultItems(
            PackingListId id, PackingListName name, TravelDays days, Gender gender,
            Temperature temperature, Localization localization
        )
        {
            throw new System.NotImplementedException();
        }
    }
}