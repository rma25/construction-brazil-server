using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace construction_brazil_server.Entities.Static
{
    [Index(nameof(NumeroDeDdd), nameof(Criado), IsUnique = false)]
    [Table("Ddds", Schema = "dbo")]
    public class Ddd
    {
        [Key]
        [Column(TypeName = "bigint", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DddId { get; set; }

        /// <summary>
        /// 11,12,13
        /// </summary>
        [Required]
        [Column(TypeName = "int")]
        public int NumeroDeDdd { get; set; }

        [Required]
        [Column(TypeName = "datetimeoffset(7)")]
        [DefaultValue("getutcdate()")]
        public DateTimeOffset Criado { get; set; }
    }
}
