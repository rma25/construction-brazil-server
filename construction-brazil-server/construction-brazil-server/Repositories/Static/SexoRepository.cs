using construction_brazil_server.DataStores;
using construction_brazil_server.Dtos.Static;
using Microsoft.EntityFrameworkCore;

namespace construction_brazil_server.Interfaces.Static
{
    public class SexoRepository : ISexoRepository
    {
        private readonly ConstructionBrazil_Context _context;

        public SexoRepository(ConstructionBrazil_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SexoDto>> GetAsync()
        {
            var dtos = await _context.Sexos
                                     .Select(x => new SexoDto
                                     {
                                         Id = x.SexoId,
                                         Tipo = x.Tipo
                                     })
                                     .ToListAsync();

            return dtos;
        }
    }
}
