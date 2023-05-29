using construction_brazil_server.Entities.Static;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace construction_brazil_server.Entities.Logs
{
    [Index(nameof(ProfissionalTypeId), nameof(ContatoId), nameof(EnderecoId), nameof(Criado), IsUnique = false)]
    [Table("Profissionals", Schema = "dbo")]
    public class Profissional
    {
        [Key]
        [Column(TypeName = "bigint", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProfissionalId { get; set; }

        [Required]
        [ForeignKey("ProfissionalTypeId")]
        [Column(TypeName = "bigint")]
        public long ProfissionalTypeId { get; set; }
        public virtual ProfissionalType ProfissionalType { get; set; }

        [Required]
        [ForeignKey("EstadoId")]
        [Column(TypeName = "bigint")]
        public long ContatoId { get; set; }
        public virtual Contato Contato { get; set; }

        [Required]
        [ForeignKey("EnderecoId")]
        [Column(TypeName = "bigint")]
        public long EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        [Column(TypeName = "varchar(500)")]
        [MaxLength(500)]
        public string? Observacoes { get; set; }

        [Column(TypeName = "varchar(11)")]
        [MaxLength(11)]
        public string? Pis { get; set; }

        [Column(TypeName = "varchar(32)")]
        [MaxLength(32)]
        public string? Rg { get; set; }

        [Column(TypeName = "varchar(32)")]
        [MaxLength(32)]
        public string? Pix { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Ativo { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Sindicalizado { get; set; }

        [Required]
        [Column(TypeName = "datetimeoffset(7)")]
        [DefaultValue("getutcdate()")]
        public DateTimeOffset Criado { get; set; }

        [Column(TypeName = "datetimeoffset(7)")]
        public DateTimeOffset? Modificado { get; set; }

        [Required]
        [Column(TypeName = "uniqueidentifier")]
        [DefaultValue("NEWID()")]
        public Guid ProfissionalKey { get; set; }
    }
}
