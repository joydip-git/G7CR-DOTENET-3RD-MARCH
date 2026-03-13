namespace BusinessEntities
{
    public class Product
    {
        public Product()
        {
            
        }

        public Product(int id, string name, decimal? price, string? description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public string? Description { get; set; }

        public override bool Equals(object? obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            if (obj is Product p)
            {
                return this.Id.Equals(p.Id);
            }
            else
                throw new ArgumentException($"{nameof(obj)} is not of type {nameof(Product)}");
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            return this.Id.GetHashCode() * prime;
        }

        public override string? ToString() =>
            $"Name:{Name}, Price:{Price}";
    }
}
