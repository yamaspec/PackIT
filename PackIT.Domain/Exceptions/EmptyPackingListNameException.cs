using PackIT.SharedAbstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    public class EmptyPackingListNameException : PackITException
    {
        public EmptyPackingListNameException() : base("packing list name cannot be empty")
        {
        }
    }
}