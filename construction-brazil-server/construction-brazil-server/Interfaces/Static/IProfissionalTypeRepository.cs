using construction_brazil_server.Dtos.Static;
using construction_brazil_server.Interfaces.Shared;

namespace construction_brazil_server.Interfaces.Static
{
    public interface IProfissionalTypeRepository : IRepository
    {
        public Task<IEnumerable<ProfissionalTypeDto>> GetAsync();
    }
}
