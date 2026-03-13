using BusinessEntities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class ProductRepository : IRepository<Product, int>
    {
        string connectionString = "server=JOYDIP-PC\\SQLEXPRESS;database=appdb;Integrated Security=True;Trust Server Certificate=True;";

        public Product? Get(int id)
        {
            Product? p = null;
            SqlConnection? connection = null;
            SqlCommand? command = null;
            SqlDataReader? reader = null;
            string fetchQuery = "select productid as ID, productname as NAME, price as PRICE, product_description as DESCRIPTION from products where productid=@id";
            try
            {
                connection = new(connectionString);              
                command = connection.CreateCommand();
                command.CommandText = fetchQuery;

                //SqlParameter idParam = new();
                //idParam.ParameterName = "@id";
                //idParam.Value = id;
                //idParam.Direction = ParameterDirection.Input;
                //idParam.SqlDbType = SqlDbType.Int;
                //command.Parameters.Add(idParam);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                reader = command.ExecuteReader();
                if(reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        p = new()
                        {
                            Id = (int)reader["ID"],
                            Name = (string)reader["NAME"],
                            Price = (decimal?)reader["PRICE"],
                            Description = (string?)reader["DESCRIPTION"]
                        };
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                connection?.Close();
            }
            return p;
        }

        public IEnumerable<Product>? GetAll()
        {
            SqlConnection? connection = null;
            SqlCommand? command = null;
            SqlDataReader? reader = null;
            HashSet<Product>? products = null;

            string fetchAllQuery = "select productid as ID, productname as NAME, price as PRICE, product_description as DESCRIPTION from products";

            try
            {
                connection = new(connectionString);             

                command = connection?.CreateCommand();
                if (command != null)
                {
                    command.CommandText = fetchAllQuery;

                    connection?.Open();
                    reader = command.ExecuteReader();

                    if (reader != null && reader.HasRows)
                    {
                        products = [];
                        while (reader.Read())
                        {
                            Product p = new()
                            {
                                Id = (int)reader["ID"],
                                Name = (string)reader["NAME"],
                                Price = (decimal?)reader["PRICE"],
                                Description = (string?)reader["DESCRIPTION"]
                            };
                            products.Add(p);
                        }
                        reader.Close();
                    }
                }
            }
            catch
            {
                throw;
            }
            return products;
        }
    }
}
