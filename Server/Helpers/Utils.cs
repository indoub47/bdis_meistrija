#nullable enable
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace bdis_meistrija.Server.Helpers
{
    public static class Utils
    {
        public static T? GetValueOrNull<T>(string columnName, SqlDataReader reader) where T : struct
        {
            if (reader.IsDBNull(reader.GetOrdinal(columnName))) return null;
            return (T)(reader[columnName]);
        }
        public static string? GetStringOrNull<T>(string columnName, SqlDataReader reader)
        {
            if (reader.IsDBNull(reader.GetOrdinal(columnName))) return null;
            string val = reader.GetString(reader.GetOrdinal(columnName));
            if (val == "") return null;
            return val;
        }

        public static void AddNullableParameter(string parameterName, System.Data.SqlDbType parameterType, object parameterValue, SqlParameterCollection collection, int parameterSize = 12)
        {
            SqlParameter param = new SqlParameter(parameterName, parameterType, parameterSize);
            if (parameterValue == null || parameterValue.ToString() == "")
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = parameterValue;
            }
            collection.Add(param);
        }
    }
}
