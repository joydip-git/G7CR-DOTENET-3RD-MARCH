using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ProductDTO
    {
        //[Required]
        public int ProductId { get; set; }

        //[Required(ErrorMessage = "product name is required")]
        //[MaxLength(50)]
        //[EmailAddress]
        //[RegularExpression("")]
        public required string ProductName { get; set; } = string.Empty;

        //[Required]
        //[Range(0,10000)]
        public decimal? Price { get; set; }

        //[Required]
        public string? Description { get; set; }
    }

    //public class Sample
    //{
    //    public Sample()
    //    {
    //        var dto = new ProductDTO() { ProductName = "" };
    //    }
    //}
}
