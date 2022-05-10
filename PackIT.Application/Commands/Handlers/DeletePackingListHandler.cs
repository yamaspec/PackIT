using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.SharedAbstractions.Commands;
using System;
using System.Threading.Tasks;

namespace PackIT.Application.Commands.Handlers
{
    internal sealed class DeletePackingListHandler : ICommandHandler<DeletePackingList>
    {
        public readonly IPackingListRepository _repository;

        public DeletePackingListHandler(IPackingListRepository repository)
            => _repository = repository;

        public async Task HandleAsync(DeletePackingList command)
        {
            // This validation is used by four handlers. An extension method could be implemented
            // to be used instead.
            var packingList = await _repository.GetAsync(command.Id);
            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.Id);
            }

            await _repository.DeleteAsync(packingList);
        }
    }
}