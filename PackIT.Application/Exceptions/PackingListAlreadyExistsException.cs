using PackIT.SharedAbstractions.Exceptions;

namespace PackIT.Application.Exceptions
{
    public class PackingListAlreadyExistsException : PackITException
    {
        public string Name { get; }

        public PackingListAlreadyExistsException(string name) : base($"Packing List with name '{name}' already exists")
        {
            Name = name;
        }
    }
}