using Microsoft.Data.SqlClient;
using System.Data;

namespace Centralis.Data.Interfaces.Clients
{
    public interface IDbClient
    {
        Task<T?> GetSingleAsync<T>(string sql, Func<SqlDataReader, T> data, CommandType type = CommandType.Text, Dictionary<string, object?>? inputs = null);
        Task<IEnumerable<T>> GetAsync<T>(string sql, Func<SqlDataReader, T> data, CommandType type = CommandType.Text, Dictionary<string, object?>? inputs = null);
    }
}
