using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreDemo.models
{
    //[Table("products")]
    //public class Product
    //{
    //    [Key]
    //    [Column("productid", TypeName = "int")]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    [Required]
    //    public int ProductId { get; set; }

    //    [Column("productname", TypeName = "varchar(50)")]
    //    [Required]
    //    public required string ProductName { get; set; }

    //    [Column("price", TypeName = "decimal(18,2)")]
    //    public decimal? Price { get; set; }

    //    [Column("product_description", TypeName = "varchar(max)")]
    //    public string? Description { get; set; }

    //    public int CategoryId { get; set; }

    //    [ForeignKey("CategoryId")]
    //    public Category? Category { get; set; }
    //}

    public class Product
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}