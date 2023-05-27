using construction_brazil_server.Entities.Static;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace construction_brazil_server.Entities.Logs
{
    [Index(nameof(Cep), nameof(Criado), IsUnique = false)]
    [Table("Enderecos", Schema = "dbo")]
    public class Endereco
    {
        [Key]
        [Column(TypeName = "bigint", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EnderecoId { get; set; }
        
        [Column(TypeName = "varchar(64)")]
        [MaxLength(64)]
        public string Rua { get; set; }
       
        [Column(TypeName = "varchar(64)")]
        [MaxLength(64)]
        public string Complemento { get; set; }

        [Column(TypeName = "varchar(120)")]
        [MaxLength(120)]
        public string Bairro { get; set; }

        [Column(TypeName = "varchar(85)")]
        [MaxLength(85)]
        public string Cidade { get; set; }

        [ForeignKey("EstadoId")]
        [Column(TypeName = "bigint")]
        public long EstadoId { get; set; }
        public virtual Estado Estado { get; set; }

        [Required]
        [Column(TypeName = "varchar(9)")]
        [MaxLength(9)]
        public string Cep { get; set; }     

        [Required]
        [Column(TypeName = "datetimeoffset(7)")]
        [DefaultValue("getutcdate()")]
        public DateTimeOffset Criado { get; set; }

        [Column(TypeName = "datetimeoffset(7)")]
        public DateTimeOffset? Modificado { get; set; }
    }
}
