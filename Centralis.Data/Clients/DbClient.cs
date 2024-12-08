using Centralis.Data.Interfaces.Clients;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Centralis.Data.Clients
{
    public class DbClient : IDbClient
    {
        private static string? _connectionString;

        public DbClient(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException("connection string is null");

            _connectionString = connectionString;
        }

        public async Task<T?> GetSingleAsync<T>(string sql, Func<SqlDataReader, T> data, CommandType type = CommandType.Text, Dictionary<string, object?>? inputs = null)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            using var cmd = new SqlCommand(sql, conn);
            cmd.CommandType = type;

            if (inputs != null)
            {
                foreach (var input in inputs)
                {
                    cmd.Parameters.AddWithValue($"@{input.Key}", input.Value ?? DBNull.Value);
                }
            }

            using var reader = await cmd.ExecuteReaderAsync();

            if (reader.Read())
            {
                return data(reader);
            }

            return default;
        }

        public async Task<IEnumerable<T>> GetAsync<T>(string sql, Func<SqlDataReader, T> data, CommandType type = CommandType.Text, Dictionary<string, object?>? inputs = null)
        {
            var rows = new List<T>();

            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            using var cmd = new SqlCommand(sql, conn);
            cmd.CommandType = type;

            if (inputs != null)
            {
                foreach (var input in inputs)
                {
                    cmd.Parameters.AddWithValue($"@{input.Key}", input.Value ?? DBNull.Value);
                }
            }

            using var reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                rows.Add(data(reader));
            }

            return rows;
        }
    }
}
