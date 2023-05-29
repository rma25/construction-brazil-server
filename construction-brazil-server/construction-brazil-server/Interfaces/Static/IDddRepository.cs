using construction_brazil_server.Dtos.Static;

namespace construction_brazil_server.Interfaces.Static
{
    public interface IDddRepository
    {
        public Task<IEnumerable<DddDto>> GetAsync();
    }
}
