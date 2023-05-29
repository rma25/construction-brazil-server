using construction_brazil_server.Controllers.Base;
using construction_brazil_server.Interfaces.Services;
using construction_brazil_server.Interfaces.Static;
using Microsoft.AspNetCore.Mvc;

namespace construction_brazil_server.Controllers.Static
{
    [ApiController]
    [Route("/Estado")]
    public class EstadoController : BaseController
    {
        private readonly IEstadoRepository _estadoRepo;

        public EstadoController(ILogService logService, IEstadoRepository estadoRepo) : base(logService)
        {
            _estadoRepo = estadoRepo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _estadoRepo.GetAsync());
        }
    }
}
