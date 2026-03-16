using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("products")]
public class Product
{
    [Key]
    [Column("productid", TypeName = "int")]
    [Required]
    public required int ProductId { get; set; }

    [Column("productname", TypeName = "varchar(50)")]
    [Required]
    public required string ProductName { get; set; }

    [Column("price", TypeName = "decimal(18,2)")]
    public decimal? Price { get; set; }

    [Column("product_description", TypeName ="varchar(max)")]
    public string? Description { get; set; }
}