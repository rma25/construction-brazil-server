using System.ComponentModel.DataAnnotations;

namespace construction_brazil_server.Dtos.Static
{
    public class SexoDto
    {
        public SexoDto()
        {
            Tipo = string.Empty;
        }

        public long Id { get; init; }

        [Required]
        public string Tipo { get; init; }
    }
}
