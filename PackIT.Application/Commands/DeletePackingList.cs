using System;
using PackIT.SharedAbstractions.Commands;

namespace PackIT.Application.Commands
{
    public record DeletePackingList(Guid Id) : ICommand;
}