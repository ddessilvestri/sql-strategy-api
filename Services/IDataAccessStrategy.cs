using System.Collections.Generic;
using System.Threading.Tasks;

namespace sql_strategy_api.Services
{
    public interface IDataAccessStrategy
    {
        Task<IEnumerable<T>> ExecuteAsync<T>(string operationName, object parameters);
    }
}