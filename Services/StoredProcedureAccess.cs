using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace sql_strategy_api.Services
{
    public class StoredProcedureAccess : IDataAccessStrategy
    {
        private readonly string _connectionString;

        public StoredProcedureAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public async Task<IEnumerable<T>> ExecuteAsync<T>(string storedProcName, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var result = await connection.QueryAsync<T>(
                storedProcName,
                param: parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}