using BusinessEntities;
using Microsoft.Data.SqlClient;
using static DataAccessLayer.Utility.Converter;
using static DataAccessLayer.Utility.Constants;
//using static DataAccessLayer.Utility.DbUtility;
using System.Data;


namespace DataAccessLayer
{
    public class ProductRepository : IRepository<ProductDTO, int>
    {

        public bool Add(ProductDTO data)
        {
            SqlConnection? connection = null;
            SqlCommand? command = null;

            try
            {
                connection = new(CONNECTION_STRING);
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = ADD_PRODUCT_QUERY;

                //var pmid = CreateParameter("@id", SqlDbType.Int, value: data.Id);
                //var pmname = CreateParameter("@name", SqlDbType.VarChar, value: data.Name);
                //var pmprice = CreateParameter("@price", SqlDbType.Decimal, value: data.Price);
                //var pmdesc = CreateParameter("@desc", SqlDbType.VarChar, value: data.Description);
                //var pmresult = CreateParameter("@result", SqlDbType.Int, direction: ParameterDirection.Output);

                //command.Parameters.Add(pmid);
                //command.Parameters.Add(pmname);
                //command.Parameters.Add(pmprice);
                //command.Parameters.Add(pmdesc);
                //command.Parameters.Add(pmresult);

                command.Parameters.AddWithValue("@id", data.Id);
                command.Parameters.AddWithValue("@name", data.Name);
                command.Parameters.AddWithValue("@price", data.Price);
                command.Parameters.AddWithValue("@desc", data.Description);

                var pmres = command.Parameters.Add("@result", SqlDbType.Int);
                pmres.Direction = ParameterDirection.Output;

                connection.Open();

                _ = command.ExecuteNonQuery();
                int result = (int)pmres.Value;                
                return result > 0;

                //no output parameter in insert query
                //int res = command.ExecuteNonQuery();
                //return res > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                connection?.Close();
            }
        }

        public bool Delete(int id)
        {
            SqlConnection? connection = null;
            SqlCommand? command = null;
            try
            {
                connection = new(CONNECTION_STRING);
                command = connection.CreateCommand();
                command.CommandText = DELETE_PRODUCT_QUERY;

                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                connection?.Close();
            }
        }

        public ProductDTO? Get(int id)
        {
            ProductDTO? p = null;
            SqlConnection? connection = null;
            SqlCommand? command = null;
            SqlDataReader? reader = null;

            try
            {
                connection = new(CONNECTION_STRING);
                command = connection.CreateCommand();
                command.CommandText = FETCH_QUERY;
                command.CommandType = CommandType.StoredProcedure;
                //SqlParameter idParam = new();
                //idParam.ParameterName = "@id";
                //idParam.Value = id;
                //idParam.Direction = ParameterDirection.Input;
                //idParam.SqlDbType = SqlDbType.Int;
                //command.Parameters.Add(idParam);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        p = ToProduct(reader);
                    }
                    reader.Close();
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

        public IEnumerable<ProductDTO>? GetAll()
        {
            SqlConnection? connection = null;
            SqlCommand? command = null;
            SqlDataReader? reader = null;
            HashSet<ProductDTO>? products = null;

            try
            {
                connection = new(CONNECTION_STRING);

                command = connection?.CreateCommand();
                if (command != null)
                {
                    command.CommandText = FETCH_ALL_PRODUCT_QUERY;
                    command.CommandType = CommandType.StoredProcedure;
                    connection?.Open();
                    reader = command.ExecuteReader();

                    if (reader != null && reader.HasRows)
                    {
                        products = [];
                        while (reader.Read())
                        {
                            ProductDTO p = ToProduct(reader);
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

        public bool Update(int id, ProductDTO data)
        {
            SqlConnection? connection = null;
            SqlCommand? command = null;
            try
            {
                connection = new(CONNECTION_STRING);
                command = connection.CreateCommand();
                command.CommandText = UPDATE_PRODUCT_QUERY;

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", data.Name);
                command.Parameters.AddWithValue("@price", data.Price);
                command.Parameters.AddWithValue("@desc", data.Description);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                connection?.Close();
            }
        }
    }
}
