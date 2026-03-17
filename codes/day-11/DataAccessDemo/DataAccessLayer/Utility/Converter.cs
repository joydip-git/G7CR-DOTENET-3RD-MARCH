using BusinessEntities;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Utility
{
    public static class Converter
    {
        public static ProductDTO ToProduct(SqlDataReader reader)
        {
            return new()
            {
                Id = (int)reader["ID"],
                Name = (string)reader["NAME"],
                Price = (decimal?)reader["PRICE"],
                Description = (string?)reader["DESCRIPTION"]
            };
        }
    }
}
