namespace WebApplication1.Models
{
    public class ProductDTO
    {
        public string? Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}
