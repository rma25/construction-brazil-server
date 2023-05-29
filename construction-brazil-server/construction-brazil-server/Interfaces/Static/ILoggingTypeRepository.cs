using construction_brazil_server.Dtos.Static;
using construction_brazil_server.Interfaces.Shared;

namespace construction_brazil_server.Interfaces.Static
{
    public interface ILoggingTypeRepository : IRepository
    {
        public Task<IEnumerable<LoggingTypeDto>> GetAsync();
    }
}
