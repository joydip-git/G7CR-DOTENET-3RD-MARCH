namespace ProductWebApp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }

        public override bool Equals(object? obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            if (obj is ProductModel p)
            {
                return Id.Equals(p.Id);
            }
            else
                throw new ArgumentException($"{nameof(obj)} is not of type {nameof(ProductModel)}");
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            return Id.GetHashCode() * prime;
        }

        public override string? ToString() =>
            $"Id:{Id}, Name:{Name}, Price:{Price}";
    }
}
