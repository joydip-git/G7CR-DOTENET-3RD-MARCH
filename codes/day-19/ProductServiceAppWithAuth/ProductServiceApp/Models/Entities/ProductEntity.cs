namespace ProductServiceApp.Models.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}
