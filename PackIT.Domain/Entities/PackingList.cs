using System;
using System.Collections.Generic;
using System.Linq;
using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;
using PackIT.SharedAbstractions.Domain;

namespace PackIT.Domain.Entities
{
    public class PackingList : AggregateRoot<Guid>
    {
        public Guid Id { get; private set; }

        private PackingListName _name;
        private Localization _localization;

        public readonly LinkedList<PackingItem> _items = new();

        internal PackingList(Guid id, PackingListName name, Localization localization, LinkedList<PackingItem> items)
        {
            Id = id;
            _name = name;
            _localization = localization;
        }

        public void AddItem(PackingItem item)
        {
            if (_items.Any(i => i.Name == item.Name))
            {
                throw new PackingItemAlreadyExistException(_name, item.Name);
            }

            _items.AddLast(item);
        }
    }
}