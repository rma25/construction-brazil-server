using construction_brazil_server.Controllers.Base;
using construction_brazil_server.Interfaces.Services;
using construction_brazil_server.Interfaces.Static;
using Microsoft.AspNetCore.Mvc;

namespace construction_brazil_server.Controllers.Static
{
    [ApiController]
    [Route("/Sexo")]
    public class SexoController : BaseController
    {
        private readonly ISexoRepository _sexoRepo;

        public SexoController(ILogService logService, ISexoRepository sexoRepo) : base(logService)
        {
            _sexoRepo = sexoRepo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _sexoRepo.GetAsync());
        }
    }
}
