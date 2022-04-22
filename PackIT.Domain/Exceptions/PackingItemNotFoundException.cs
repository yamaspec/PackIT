using PackIT.SharedAbstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    public class PackingItemNotFoundException : PackITException
    {
        public string ItemName { get; }

        public PackingItemNotFoundException(string itemName) : base($"Packing item '{itemName}' was not found")
            => ItemName = itemName;
    }
}