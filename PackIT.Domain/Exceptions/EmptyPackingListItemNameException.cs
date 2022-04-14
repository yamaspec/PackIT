using PackIT.SharedAbstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    public class EmptyPackingListItemNameException : PackITException
    {
        public EmptyPackingListItemNameException() : base("Packing Item name cannot be empty")
        {
        }
    }
}