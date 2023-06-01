using System.ComponentModel.DataAnnotations;

namespace construction_brazil_server.Dtos.Static
{
    public class EstadoDto
    {
        public EstadoDto()
        {
            Nome = string.Empty;
            Uf = string.Empty;
        }

        public long Id { get; init; }

        [Required]
        public string Nome { get; init; }

        [Required]
        public string Uf { get; init; }
    }
}
