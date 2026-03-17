using Microsoft.Data.SqlClient;

SqlConnection? connection = null;
SqlCommand? command = null;
SqlDataReader? reader = null;

string fetchAllQuery = "select productid as ID, productname as NAME, price as PRICE, product_description as DESCRIPTION from products";
try
{
    connection = new("server=JOYDIP-PC\\SQLEXPRESS;database=appdb;Integrated Security=True;Trust Server Certificate=True;");
    connection?.Open();
    //Console.WriteLine(connection?.State.ToString());

    //command = new();
    //command?.CommandText = fetchAllQuery;
    //command?.Connection = connection;

    //command = new SqlCommand(fetchAllQuery, connection);
    command = connection?.CreateCommand();
    //command?.CommandText = fetchAllQuery;
    if(command != null)
    {
        command.CommandText = fetchAllQuery;
        reader = command.ExecuteReader();

        if(reader !=null && reader.HasRows)
        {
            while (reader.Read())
            {
                int id = (int)reader["ID"];
                //int id = reader.GetInt32(0);
                //int id = (int)reader.GetValue(0);
                string name = (string)reader["NAME"];
                decimal? price = (decimal?)reader["PRICE"];
                string? desc = (string?)reader["DESCRIPTION"];
                Console.WriteLine($"Id:{id}, Name:{name}, Price:{price}, Description:{desc}");
            }
            reader.Close();
        }
    }


}
catch (Exception e)
{
    Console.WriteLine(e);
}
finally
{
    connection?.Close();
}
