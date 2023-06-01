using System.ComponentModel.DataAnnotations;

namespace construction_brazil_server.Dtos.Static
{
    public class DddDto
    {
        public long Id { get; init; }

        [Required]
        public int NumeroDeDdd { get; init; }
    }
}
