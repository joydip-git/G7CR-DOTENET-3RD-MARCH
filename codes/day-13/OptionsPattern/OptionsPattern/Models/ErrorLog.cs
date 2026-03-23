using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptionsPattern.Models
{
    [Table("errorlogs")]
    public class ErrorLog
    {
        [Key]
        [Column("log_id", TypeName ="int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        public int LogId { get; set; }

        [Column("logged_at",TypeName ="datetime")]
        [Required]
        public required DateTime LoggedAt { get; set; }

        [Column("error_message", TypeName = "varchar(max)")]
        [Required]
        public required string Message { get; set; }

        [Column("method_name", TypeName = "varchar(50)")]
        [Required]
        public required string Method { get; set; }

        [Column("source", TypeName = "varchar(50)")]
        [Required]
        public required string Application { get; set; }

        [Column("details", TypeName = "varchar(max)")]        
        public string? Details { get; set; }
    }
}
