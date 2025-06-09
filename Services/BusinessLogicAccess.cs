using System.Collections.Generic;
using System.Threading.Tasks;
using sql_strategy_api.Models;

namespace sql_strategy_api.Services
{
    public class BusinessLogicAccess : IDataAccessStrategy
    {
        public async Task<IEnumerable<T>> ExecuteAsync<T>(string operationName, object parameters)
        {
            if (typeof(T) == typeof(User) && operationName == "GetUsersInMemory")
            {
                var users = new List<User>
                {
                    new User { Id = 1, FullName = "Alice Johnson", IsActive = true },
                    new User { Id = 2, FullName = "Bob Smith", IsActive = false }
                };

                // Simula una operación asincrónica (como si viniera de una base externa o API)
                await Task.Delay(50);

                // ⚠️ Se requiere conversión manual para que compile correctamente
                return users as IEnumerable<T> ?? new List<T>();
            }

            return new List<T>();
        }
    }
}