using construction_brazil_server.Dtos.Static;

namespace construction_brazil_server.Interfaces.Static
{
    public interface IEstadoRepository
    {
        public Task<IEnumerable<EstadoDto>> GetAsync();
    }
}
