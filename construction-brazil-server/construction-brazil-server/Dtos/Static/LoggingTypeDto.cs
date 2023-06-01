using System.ComponentModel.DataAnnotations;

namespace construction_brazil_server.Dtos.Static
{
    public class LoggingTypeDto
    {
        public LoggingTypeDto()
        {
            Nome = string.Empty;
        }

        public long Id { get; init; }

        [Required]
        public string Nome { get; init; }        
    }
}
