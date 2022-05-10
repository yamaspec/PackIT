using PackIT.Domain.Consts;
using PackIT.SharedAbstractions.Commands;
using System;

namespace PackIT.Application.Commands
{
    public record CreatePackingListWithItems(Guid Id, string Name, ushort Days, Gender Gender,
        LocalizationWriteModel Localization) : ICommand;

    // Write model postfix because is in the command side.
    public record LocalizationWriteModel(string City, string Country);
}