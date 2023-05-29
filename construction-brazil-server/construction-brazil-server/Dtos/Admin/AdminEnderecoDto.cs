using System.ComponentModel.DataAnnotations;

namespace construction_brazil_server.Dtos.Admin
{
    public class AdminEnderecoDto
    {
        public long Id { get; init; }

        [MaxLength(64)]
        public string? Rua { get; init; }

        [MaxLength(64)]
        public string? Complemento { get; init; }

        [MaxLength(120)]
        public string? Bairro { get; init; }

        [MaxLength(85)]
        public string? Cidade { get; init; }

        [Required]
        [MaxLength(9)]
        public string Cep { get; init; }

        // FK
        public long? EstadoId { get; init; }
    }
}
