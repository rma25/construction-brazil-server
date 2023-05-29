using construction_brazil_server.Dtos.Static;

namespace construction_brazil_server.Interfaces.Static
{
    public interface ISexoRepository
    {
        public Task<IEnumerable<SexoDto>> GetAsync();
    }
}
