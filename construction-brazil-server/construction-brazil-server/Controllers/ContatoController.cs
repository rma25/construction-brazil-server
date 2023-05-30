using construction_brazil_server.Controllers.Base;
using construction_brazil_server.Dtos.Admin;
using construction_brazil_server.Dtos.Filters;
using construction_brazil_server.Interfaces;
using construction_brazil_server.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace construction_brazil_server.Controllers
{
    [ApiController]
    [Route("/Contato")]
    public class ContatoController : BaseController
    {
        private readonly IContatoRepository _contatoRepo;

        public ContatoController(ILogService logService, IContatoRepository contatoRepo) : base(logService)
        {
            _contatoRepo = contatoRepo;
        }

        [HttpGet("cpf/{cpf}/id/{id}/IsCpfUnique")]
        public async Task<ActionResult> IsCpfUnique([FromRoute] string cpf, [FromRoute] long id)
        {
            if (string.IsNullOrEmpty(cpf))
                return HandleBadRequest(nameof(cpf));

            return Ok(await _contatoRepo.IsCpfUniqueAsync(cpf, id));
        }

    }
}
