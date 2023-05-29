using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace construction_brazil_server.Entities.Static
{
    [Index(nameof(Criado), IsUnique = false)]
    [Table("LoggingTypes", Schema = "dbo")]
    public class LoggingType
    {
        [Key]
        [Column(TypeName = "bigint", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LoggingTypeId { get; set; }

        /// <summary>
        /// Information, Critical, Elasticsearch
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(256)")]
        [MaxLength(256)]
        public string? Descricao { get; set; }

        [Required]
        [Column(TypeName = "datetimeoffset(7)")]
        [DefaultValue("getutcdate()")]
        public DateTimeOffset Criado { get; set; }

    }
}
