using PackIT.SharedAbstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    public class EmptyPackingListIdException : PackITException
    {
        public EmptyPackingListIdException() : base("Packing List Id cannot be empty")
        {
        }
    }
}