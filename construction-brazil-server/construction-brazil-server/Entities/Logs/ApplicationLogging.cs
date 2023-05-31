using construction_brazil_server.Entities.Static;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace construction_brazil_server.Entities.Logs
{    
    [Index(nameof(Criado), IsUnique = false)]
    [Table("ApplicationLoggings", Schema = "dbo")]
    public class ApplicationLogging
    {
        [Key]
        [Column(TypeName = "bigint", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ApplicationLoggingId { get; set; }

        //Many-To-One
        [Required]
        [ForeignKey("LoggingTypeId")]
        [Column(TypeName = "bigint")]
        public long LoggingTypeId { get; set; }
        public virtual LoggingType LoggingType { get; set; }

        //Many-To-One
        [ForeignKey("ExceptionLoggingId")]
        [Column(TypeName = "bigint")]
        public long? ExceptionLoggingId { get; set; }
        public virtual ExceptionLogging ExceptionLogging { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Mensagem { get; set; }

        [Column(TypeName = "varchar(128)")]
        [MaxLength(128)]
        public string ControllerName { get; set; }

        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string MethodName { get; set; }

        [Required]
        [Column(TypeName = "datetimeoffset(7)")]
        [DefaultValue("getutcdate()")]
        public DateTimeOffset Criado { get; set; }

    }
}
