using construction_brazil_server.Controllers.Base;
using construction_brazil_server.Interfaces.Services;
using construction_brazil_server.Interfaces.Static;
using Microsoft.AspNetCore.Mvc;

namespace construction_brazil_server.Controllers.Static
{
    [ApiController]
    [Route("/ProfissionalType")]
    public class ProfissionalTypeController : BaseController
    {
        private readonly IProfissionalTypeRepository _profissionalTypeRepo;

        public ProfissionalTypeController(ILogService logService, IProfissionalTypeRepository profissionalTypeRepo) : base(logService)
        {
            _profissionalTypeRepo = profissionalTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _profissionalTypeRepo.GetAsync());
        }
    }
}
