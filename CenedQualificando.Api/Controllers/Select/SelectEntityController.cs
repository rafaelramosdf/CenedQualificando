using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Utils;
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
            return Ok(service.ObterComboSelecao(param.Term, param.Size, param.Selected));
        }

        [HttpGet("alunos")]
        public ActionResult<SelectResult> Alunos(
            [FromServices] IAlunoService service,
            [FromQuery] SelectSearchParam param)
        {
            return Ok(service.ObterComboSelecao(param.Term, param.Size));
        }

        [HttpGet("cursos")]
        public ActionResult<SelectResult> Cursos(
            [FromServices] ICursoService service,
            [FromQuery] SelectSearchParam param)
        {
            return Ok(service.ObterComboSelecao(param.Term, param.Size));
        }

        [HttpGet("usuarios")]
        public ActionResult<SelectResult> Usuarios(
            [FromServices] IUsuarioService service,
            [FromQuery] SelectSearchParam param)
        {
            return Ok(service.ObterComboSelecao(param.Term, param.Size));
        }
    }
}
