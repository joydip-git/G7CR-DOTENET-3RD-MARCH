namespace ApplicationExceptions
{
    public class ProductNotFoundException : ApplicationException
    {
        public ProductNotFoundException() : base("product not found")
        {

        }
        public ProductNotFoundException(string message) : base(message)
        {

        }
        public ProductNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
