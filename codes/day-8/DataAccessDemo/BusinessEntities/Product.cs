namespace BusinessEntities
{
    public class Product(int id, string name, decimal? price, string? description)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public decimal? Price { get; set; } = price;
        public string? Description { get; set; } = description;

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
