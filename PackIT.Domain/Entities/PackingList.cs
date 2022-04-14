using System;
using System.Collections.Generic;
using System.Linq;
using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;
using PackIT.SharedAbstractions.Domain;

namespace PackIT.Domain.Entities
{
    public class PackingList : AggregateRoot<PackingListId>
    {
        public PackingListId Id { get; private set; }

        private PackingListName _name;
        private Localization _localization;

        public readonly LinkedList<PackingItem> _items = new();

        internal PackingList(Guid id, PackingListName name, Localization localization, LinkedList<PackingItem> items)
            : this(id, name, localization)
        {
            AddItems(items);
        }

        internal PackingList(Guid id, PackingListName name, Localization localization)
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
            AddEvent(new PackingItemAdded(this, item));
        }

        public void AddItems(IEnumerable<PackingItem> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        public void PackItem(string itemName)
        {
            var item = GetItem(itemName);
            var packedItem = item with { IsPacked = true };
            _items.Find(item).Value = packedItem;
            AddEvent(new PackingItemPacked(this, packedItem));
        }

        public void RemoveItem(string itemName)
        {
            var item = GetItem(itemName);
            _items.Remove(item);
            AddEvent(new PackingItemRemoved(this, item));
        }

        private PackingItem GetItem(string itemName)
        {
            var item = _items.SingleOrDefault(i => i.Name == itemName);
            if (item is null)
            {
                throw new PackingItemNotFoundException(itemName);
            }
            return item;
        }
    }
}