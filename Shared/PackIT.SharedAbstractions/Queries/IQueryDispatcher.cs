using System.Threading.Tasks;

namespace PackIT.SharedAbstractions.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}