using System.ComponentModel.DataAnnotations;

namespace construction_brazil_server.Dtos.Admin
{
    public class AdminContato
    {
        [Required]
        [MaxLength(100)]
        public string Nome { get; init; }

        [Required]
        [MaxLength(100)]
        public string Sobrenome { get; init; }

        [Required]
        [MaxLength(14)]
        public string Cpf { get; init; }

        [Required]
        public DateTimeOffset DataDeNascimento { get; init; }

        [MaxLength(9)]
        public string Telefone { get; init; }

        [MaxLength(64)]
        public string Profissao { get; init; }

        // FK
        public long DddId { get; init; }

        // FK
        public long SexoId { get; init; }
    }
}
