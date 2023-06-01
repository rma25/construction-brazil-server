using System.ComponentModel.DataAnnotations;

namespace construction_brazil_server.Dtos.Static
{
    public class ProfissionalTypeDto
    {
        public ProfissionalTypeDto()
        {
            Tipo = string.Empty;
        }

        public long Id { get; init; }

        [Required]
        public string Tipo { get; init; }
    }
}
