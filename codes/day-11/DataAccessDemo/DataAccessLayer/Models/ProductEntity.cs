namespace DataAccessLayer.Models
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}
