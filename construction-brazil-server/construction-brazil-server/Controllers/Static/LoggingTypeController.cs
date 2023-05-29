using construction_brazil_server.Controllers.Base;
using construction_brazil_server.Interfaces.Services;
using construction_brazil_server.Interfaces.Static;
using Microsoft.AspNetCore.Mvc;

namespace construction_brazil_server.Controllers.Static
{
    [ApiController]
    [Route("/LoggingType")]
    public class LoggingTypeController : BaseController
    {
        private readonly ILoggingTypeRepository _loggingTypeRepo;

        public LoggingTypeController(ILogService logService, ILoggingTypeRepository loggingTypeRepo) : base(logService)
        {
            _loggingTypeRepo = loggingTypeRepo;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _loggingTypeRepo.GetAsync());
        }
    }
}
