using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace construction_brazil_server.Entities.Static
{
    [Index(nameof(Tipo), nameof(Criado), IsUnique = false)]
    [Table("ProfissionalTypes", Schema = "dbo")]
    public class ProfissionalType
    {
        [Key]
        [Column(TypeName = "bigint", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProfissionalTypeId { get; set; }

        /// <summary>
        /// Rodeio, outros tipos de evento, etc.
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(10)")]
        [MaxLength(10)]
        public string Tipo { get; set; }

        [Required]
        [Column(TypeName = "datetimeoffset(7)")]
        [DefaultValue("getutcdate()")]
        public DateTimeOffset Criado { get; set; }
    }
}
