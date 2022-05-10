using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.SharedAbstractions.Commands;
using System.Threading.Tasks;

namespace PackIT.Application.Commands.Handlers
{
    internal sealed class AddPackingItemHandler : ICommandHandler<AddPackingItem>
    {
        private readonly IPackingListRepository _repository;

        public AddPackingItemHandler(IPackingListRepository repository)
            => _repository = repository;

        public async Task HandleAsync(AddPackingItem command)
        {
            // This validation is used by four handlers. An extension method could be implemented
            // to be used instead.
            var packingList = await _repository.GetAsync(command.PackingListId);
            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.PackingListId);
            }

            var packingItem = new PackingItem(command.Name, command.Quantity);
            packingList.AddItem(packingItem);

            await _repository.UpdateAsync(packingList);
        }
    }
}