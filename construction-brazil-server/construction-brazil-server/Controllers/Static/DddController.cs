using construction_brazil_server.Controllers.Base;
using construction_brazil_server.Interfaces.Services;
using construction_brazil_server.Interfaces.Static;
using Microsoft.AspNetCore.Mvc;

namespace construction_brazil_server.Controllers.Static
{
    [ApiController]
    [Route("/Ddd")]
    public class DddController : BaseController
    {
        private readonly IDddRepository _dddRepo;

        public DddController(ILogService logService, IDddRepository dddRepo) : base(logService)
        {
            _dddRepo = dddRepo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _dddRepo.GetAsync());
        }
    }
}
