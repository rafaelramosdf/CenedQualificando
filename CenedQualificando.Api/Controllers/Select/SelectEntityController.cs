using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers.Select
{
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/combos/entidades")] 
    public class SelectEntityController : Controller
    {
        [HttpGet("penitenciarias")]
        public ActionResult<SelectResult> Penitenciarias(
            [FromServices] IPenitenciariaService service,
            [FromQuery] SelectSearchParam param)
        {
            return Ok(service.ObterComboSelecao(param.Term, param.Size));
        }
    }
}
