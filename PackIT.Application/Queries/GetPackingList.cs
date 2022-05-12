using PackIT.Application.DTO;
using PackIT.SharedAbstractions.Queries;
using System;

namespace PackIT.Application.Queries
{
    public class GetPackingList : IQuery<PackingListDto>
    {
        public Guid Id { get; set; }
    }
}