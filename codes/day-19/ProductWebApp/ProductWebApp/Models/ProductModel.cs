using System.ComponentModel.DataAnnotations;

namespace ProductWebApp.Models
{
    public class ProductModel
    {
        //[Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(5, ErrorMessage = "length should be 50")]
        public required string Name { get; set; }

        [Required]
        [Range(100, 100000, ErrorMessage = "value should be between 100 and 100000")]
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
