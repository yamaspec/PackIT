using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.SharedAbstractions.Commands;
using System.Threading.Tasks;

namespace PackIT.Application.Commands.Handlers
{
    internal sealed class PackItemHandler : ICommandHandler<RemovePackingItem>
    {
        private readonly IPackingListRepository _repository;

        public PackItemHandler(IPackingListRepository repository)
            => _repository = repository;

        public async Task HandleAsync(RemovePackingItem command)
        {
            // This validation is used by four handlers. An extension method could be implemented
            // to be used instead.
            var packingList = await _repository.GetAsync(command.PackingListId);
            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.PackingListId);
            }

            // Mark item as packed
            packingList.PackItem(command.Name);

            await _repository.UpdateAsync(packingList);
        }
    }
}