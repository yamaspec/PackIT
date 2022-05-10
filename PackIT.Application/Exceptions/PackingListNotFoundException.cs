using System;
using PackIT.SharedAbstractions.Exceptions;

namespace PackIT.Application.Exceptions
{
    public class PackingListNotFoundException : PackITException
    {
        public Guid Id { get; }

        public PackingListNotFoundException(Guid id) : base($"Packing List '{id}' was ot found")
        {
            Id = id;
        }
    }
}