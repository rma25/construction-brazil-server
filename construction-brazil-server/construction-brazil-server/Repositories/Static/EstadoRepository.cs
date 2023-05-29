using construction_brazil_server.DataStores;
using construction_brazil_server.Dtos.Static;
using Microsoft.EntityFrameworkCore;

namespace construction_brazil_server.Interfaces.Static
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly ConstructionBrazil_Context _context;

        public EstadoRepository(ConstructionBrazil_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EstadoDto>> GetAsync()
        {
            var dtos = await _context.Estados
                                     .Select(x => new EstadoDto
                                     {
                                         Id = x.EstadoId,
                                         Nome = x.Nome,
                                         Uf = x.Uf
                                     })
                                     .ToListAsync();

            return dtos;
        }
    }
}
