using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace construction_brazil_server.Entities.Logs
{
    [Index(nameof(Type), nameof(Criado), IsUnique = false)]
    [Table("ExceptionLoggings", Schema = "dbo")]
    public class ExceptionLogging
    {
        public ExceptionLogging()
        {
            Message = string.Empty;
            StackTrace = string.Empty;
            Type = string.Empty;
        }

        [Key]
        [Column(TypeName = "bigint", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ExceptionLoggingId { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Message { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? InnerExceptionMessage { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? StackTrace { get; set; }

        [Column(TypeName = "varchar(256)")]
        [MaxLength(256)]
        public string? Source { get; set; }

        [Required]
        [Column(TypeName = "varchar(256)")]
        [MaxLength(256)]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "datetimeoffset(7)")]
        [DefaultValue("getutcdate()")]
        public DateTimeOffset Criado { get; set; }
    }
}
