using construction_brazil_server.Dtos.Static;

namespace construction_brazil_server.Interfaces.Static
{
    public interface ILoggingTypeRepository
    {
        public Task<IEnumerable<LoggingTypeDto>> GetAsync();
    }
}
