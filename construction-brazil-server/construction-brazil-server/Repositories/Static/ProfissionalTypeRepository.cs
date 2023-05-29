using construction_brazil_server.DataStores;
using construction_brazil_server.Dtos.Static;
using Microsoft.EntityFrameworkCore;

namespace construction_brazil_server.Interfaces.Static
{
    public class ProfissionalTypeRepository : IProfissionalTypeRepository
    {
        private readonly ConstructionBrazil_Context _context;

        public ProfissionalTypeRepository(ConstructionBrazil_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProfissionalTypeDto>> GetAsync()
        {
            var dtos = await _context.ProfissionalTypes
                                     .Select(x => new ProfissionalTypeDto
                                     {
                                         Id = x.ProfissionalTypeId,
                                         Tipo = x.Tipo
                                     })
                                     .ToListAsync();

            return dtos;
        }
    }
}
