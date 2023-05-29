using construction_brazil_server.DataStores;
using construction_brazil_server.Dtos.Static;
using Microsoft.EntityFrameworkCore;

namespace construction_brazil_server.Interfaces.Static
{
    public class LoggingTypeRepository : ILoggingTypeRepository
    {
        private readonly ConstructionBrazil_Context _context;

        public LoggingTypeRepository(ConstructionBrazil_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoggingTypeDto>> GetAsync()
        {
            var dtos = await _context.LoggingTypes
                                     .Select(x => new LoggingTypeDto
                                     {
                                         Id = x.LoggingTypeId,
                                         Nome = x.Nome                                         
                                     })
                                     .ToListAsync();

            return dtos;
        }
    }
}
