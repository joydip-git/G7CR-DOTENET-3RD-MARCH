using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreDemo.models
{
    //[Table("categories")]
    //public class Category
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    [Column("categoryid", TypeName = "int")]
    //    [Required]
    //    public int CategoryId { get; set; }

    //    [Column("categoryname", TypeName = "varchar(50)")]
    //    [Required]
    //    public required string CategoryName { get; set; }
    //}
    public class Category
    {
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
