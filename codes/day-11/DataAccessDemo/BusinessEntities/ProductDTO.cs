namespace BusinessEntities
{
    public class ProductDTO
    {
        public ProductDTO()
        {
            
        }

        public ProductDTO(int id, string name, decimal? price, string? description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }

        public override bool Equals(object? obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            if (obj is ProductDTO p)
            {
                return this.Id.Equals(p.Id);
            }
            else
                throw new ArgumentException($"{nameof(obj)} is not of type {nameof(ProductDTO)}");
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            return this.Id.GetHashCode() * prime;
        }

        public override string? ToString() =>
            $"Id:{Id}, Name:{Name}, Price:{Price}";
    }
}
