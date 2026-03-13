using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Utility
{
    public static class DbUtility
    {
        public static SqlParameter CreateParameter(string name, SqlDbType sqlDbType, ParameterDirection direction = ParameterDirection.Input, object? value = null)
        {
            return new()
            {
                ParameterName = name,
                SqlDbType = sqlDbType,
                Value = value,
                Direction = direction
            };
        }
    }
}
