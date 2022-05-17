using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.SharedAbstractions.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.Queries.Handlers
{
    public class SearchPackingListHandler : IQueryHandler<SearchPackingList, IEnumerable<PackingListDto>>
    {
        public Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingList query)
        {
            return null;
        }
    }
}