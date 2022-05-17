using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.SharedAbstractions.Queries;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.Queries.Handlers
{
    public class GetPackingListHandler : IQueryHandler<GetPackingList, PackingItemDto>
    {
        public async Task<PackingListDto> HandleAsync(GetPackingList query)
        {
            return null;
        }
    }
}