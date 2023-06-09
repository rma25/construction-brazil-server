﻿using construction_brazil_server.DataStores;
using construction_brazil_server.Dtos.Static;
using Microsoft.EntityFrameworkCore;

namespace construction_brazil_server.Interfaces.Static
{
    public class DddRepository : IDddRepository
    {
        private readonly ConstructionBrazil_Context _context;

        public DddRepository(ConstructionBrazil_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DddDto>> GetAsync()
        {
            var dtos = await _context.Ddds
                                     .Select(x => new DddDto
                                     {
                                         Id = x.DddId,
                                         NumeroDeDdd = x.NumeroDeDdd
                                     })
                                     .ToListAsync();

            return dtos;
        }
    }
}
