using construction_brazil_server.Entities.Static;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace construction_brazil_server.Entities.Logs
{
    [Index(nameof(Cpf), nameof(Nome), nameof(Sobrenome), nameof(DataDeNascimento), nameof(Criado), IsUnique = false)]
    [Table("Contatos", Schema = "dbo")]
    public class Contato
    {
        public Contato()
        {
            Nome = string.Empty;
            Sobrenome = string.Empty;
            Cpf = string.Empty;
        }

        [Key]
        [Column(TypeName = "bigint", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ContatoId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Sobrenome { get; set; }              

        /// <summary>
        /// This is like Social Security
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(14)")]
        [MaxLength(14)]
        public string Cpf { get; set; }

        /// <summary>
        /// Birthdate
        /// </summary>
        [Required]
        [Column(TypeName = "datetimeoffset(7)")]
        public DateTimeOffset DataDeNascimento { get; set; }

        [Column(TypeName = "varchar(256)")]
        [MaxLength(256)]
        public string? Email { get; set; }

        [Column(TypeName = "varchar(9)")]
        [MaxLength(9)]
        public string? Telefone { get; set; }

        [Column(TypeName = "varchar(64)")]
        [MaxLength(64)]
        public string? Profissao { get; set; }

        [Required]
        [ForeignKey("SexoId")]
        [Column(TypeName = "bigint")]
        public long SexoId { get; set; }
        public virtual Sexo? Sexo { get; set; }

        [ForeignKey("DddId")]
        [Column(TypeName = "bigint")]
        public long? DddId { get; set; }
        public virtual Ddd? Ddd { get; set; }

        [Required]
        [Column(TypeName = "datetimeoffset(7)")]
        [DefaultValue("getutcdate()")]
        public DateTimeOffset Criado { get; set; }

        [Column(TypeName = "datetimeoffset(7)")]
        public DateTimeOffset? Modificado { get; set; }
    }
}
