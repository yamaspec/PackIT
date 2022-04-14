using System;

namespace PackIT.SharedAbstractions.Exceptions
{
    public abstract class PackITException : Exception
    {
        protected PackITException(string message) : base(message)
        {
        }
    }
}