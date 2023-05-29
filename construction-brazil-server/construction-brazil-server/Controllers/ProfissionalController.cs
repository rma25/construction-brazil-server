using construction_brazil_server.Controllers.Base;
using construction_brazil_server.Dtos.Admin;
using construction_brazil_server.Dtos.Filters;
using construction_brazil_server.Interfaces;
using construction_brazil_server.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace construction_brazil_server.Controllers
{
    [ApiController]
    [Route("/Profissional")]
    public class ProfissionalController : BaseController
    {
        private readonly IProfissionalRepository _profissionalRepo;

        public ProfissionalController(ILogService logService, IProfissionalRepository profissionalRepo) : base(logService)
        {
            _profissionalRepo = profissionalRepo;
        }

        [HttpPost("GetAdminTotal")]
        public async Task<ActionResult> GetAdminTotal([FromBody] ProfissionalAdminFilterDto filter)
        {
            if (filter == null)
                return HandleBadRequest(nameof(filter));

            return Ok(await _profissionalRepo.GetAdminTotalAsync(filter));
        }

        [HttpPost("GetAdminPage")]
        public async Task<ActionResult> GetAdminPage([FromBody] ProfissionalAdminFilterDto filter)
        {
            if (filter == null)
                return HandleBadRequest(nameof(filter));

            return Ok(await _profissionalRepo.GetAdminPageAsync(filter));
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert([FromBody] AdminProfissionalDto profissional)
        {
            if (profissional == null)
                return HandleBadRequest(nameof(profissional));

            var newId = await _profissionalRepo.InsertAsync(profissional);

            return Ok(newId);
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromBody] AdminProfissionalDto profissional)
        {
            if (profissional == null)
                return HandleBadRequest(nameof(profissional));

            await _profissionalRepo.UpdateAsync(profissional);

            return Ok();
        }

        [HttpDelete("id/{id}/Delete")]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            if (id <= 0)
                return HandleBadRequest(nameof(id), id);
            if (!await _profissionalRepo.Exists(id))
                return HandleNotFound("Profissional does not exist.");

            await _profissionalRepo.DeleteAsync(id);

            return Ok();
        }
    }
}
