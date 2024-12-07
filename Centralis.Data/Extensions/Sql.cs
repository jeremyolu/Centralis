using Microsoft.Data.SqlClient;
using System.Data;

namespace Centralis.Data.Extensions
{
    public static class Sql
    {
        public static int? Int(this SqlDataReader reader, string column)
        {
            int index = reader.GetOrdinal(column);

            if (!reader.IsDBNull(index))
            {
                return reader.GetInt32(index);
            }

            return null;
        }

        public static long? BigInt(this SqlDataReader reader, string column)
        {
            int index = reader.GetOrdinal(column);

            if (!reader.IsDBNull(index))
            {
                return reader.GetInt64(index);
            }

            return null;
        }

        public static Guid? UniqueIdentifier(this SqlDataReader reader, string column)
        {
            int index = reader.GetOrdinal(column);

            if (!reader.IsDBNull(index))
            {
                return reader.GetGuid(index);
            }

            return null;
        }

        public static string? String(this SqlDataReader reader, string column)
        {
            int index = reader.GetOrdinal(column);

            if (!reader.IsDBNull(index))
            {
                return reader.GetString(index);
            }

            return null;
        }

        public static bool? Bool(this SqlDataReader reader, string column)
        {
            int index = reader.GetOrdinal(column);

            if (!reader.IsDBNull(index))
            {
                return reader.GetBoolean(index);
            }

            return null;
        }

        public static decimal? Decimal(this SqlDataReader reader, string column)
        {
            int index = reader.GetOrdinal(column);

            if (!reader.IsDBNull(index))
            {
                return reader.GetDecimal(index);
            }

            return null;
        }

        public static float? Float(this SqlDataReader reader, string column)
        {
            int index = reader.GetOrdinal(column);

            if (!reader.IsDBNull(index))
            {
                return reader.GetFloat(index);
            }

            return null;
        }

        public static DateTime? DateTime(this SqlDataReader reader, string column)
        {
            int index = reader.GetOrdinal(column);

            if (!reader.IsDBNull(index))
            {
                return reader.GetDateTime(index);
            }

            return null;
        }
    }
}
