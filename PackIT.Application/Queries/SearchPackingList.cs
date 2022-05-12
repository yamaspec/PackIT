using PackIT.Application.DTO;
using PackIT.SharedAbstractions.Queries;
using System.Collections.Generic;

namespace PackIT.Application.Queries
{
    public class SearchPackingList : IQuery<IEnumerable<PackingListDto>>
    {
        public string SearchPhrase { get; set; }
    }
}