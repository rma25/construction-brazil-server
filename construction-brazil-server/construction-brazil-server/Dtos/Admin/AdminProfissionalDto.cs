using System.ComponentModel.DataAnnotations;

namespace construction_brazil_server.Dtos.Admin
{
    public class AdminProfissionalDto
    {
        public long Id { get; init; }

        [MaxLength(500)]
        public string? Observacoes { get; init; }

        [MaxLength(11)]
        public string? Pis { get; init; }

        [MaxLength(32)]
        public string? Rg { get; init; }

        [MaxLength(32)]
        public string? Pix { get; init; }

        public bool Ativo { get; init; }

        public bool Sindicalizado { get; init; }

        [Required]
        public AdminContatoDto Contato { get; init; }

        [Required]
        public AdminEnderecoDto Endereco { get; init; }

        [Required]
        public long ProfissionalTypeId { get; init; }

        public DateTimeOffset Criado { get; init; }

        public DateTimeOffset? Modificado { get; init; }
    }
}
