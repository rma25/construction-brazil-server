using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace construction_brazil_server.Entities.Static
{
    [Index(nameof(Nome), nameof(Uf), nameof(Criado), IsUnique = false)]
    [Table("Estados", Schema = "dbo")]
    public class Estado
    {
        public Estado()
        {
            Nome = string.Empty;
            Uf = string.Empty;
        }

        [Key]
        [Column(TypeName = "bigint", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EstadoId { get; set; }

        /// <summary>
        /// Rio de Janeiro, Sao Paulo, etc.
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(30)")]
        [MaxLength(30)]
        public string Nome { get; set; }

        /// <summary>
        /// RJ, SP, etc.
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(2)")]
        [MaxLength(2)]
        public string Uf { get; set; }

        [Required]
        [Column(TypeName = "datetimeoffset(7)")]
        [DefaultValue("getutcdate()")]
        public DateTimeOffset Criado { get; set; }
    }
}
