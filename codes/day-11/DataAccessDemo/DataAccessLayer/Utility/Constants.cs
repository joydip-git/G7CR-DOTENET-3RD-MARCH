namespace DataAccessLayer.Utility
{
    public static class Constants
    {
        public const string CONNECTION_STRING = "server=JOYDIP-PC\\SQLEXPRESS;database=appdb;Integrated Security=True;Trust Server Certificate=True;";

        //public const string FETCH_ALL_PRODUCT_QUERY = "select productid as ID, productname as NAME, price as PRICE, product_description as DESCRIPTION from products";

        public const string FETCH_ALL_PRODUCT_QUERY = "GetAllProducts";

        //public const string FETCH_QUERY = "select productid as ID, productname as NAME, price as PRICE, product_description as DESCRIPTION from products where productid=@id";

        public const string FETCH_QUERY = "GetProduct";

        //public const string ADD_PRODUCT_QUERY = "insert into products(productname,productid,price,product_description) values(@name,@id,@price,@desc)";

        public const string ADD_PRODUCT_QUERY = "AddProduct";

        public const string UPDATE_PRODUCT_QUERY = "update products set productname=@name,price=@price,product_description=@desc where productid=@id";

        public const string DELETE_PRODUCT_QUERY = "delete from products where productid=@id";
    }
}
