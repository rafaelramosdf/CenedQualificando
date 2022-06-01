using CenedQualificando.Domain.Handlers.Aluno;
using CenedQualificando.Domain.Handlers.Curso;
using CenedQualificando.Domain.Handlers.Penitenciaria;
using CenedQualificando.Domain.Handlers.Usuario;
using CenedQualificando.Domain.Models.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers.v1
{
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/v1/combos/entidades")]
    public class ComboSelecaoEntidadeController : Controller
    {
        [HttpGet("penitenciarias")]
        public ActionResult<SelectResult> Penitenciarias(
            [FromServices] IObterComboSelecaoPenitenciariasQueryHandler handler,
            [FromQuery] SelectSearchParam param)
        {
            var result = handler.Execute(param.Term, param.Size, param.Selected);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("alunos")]
        public ActionResult<SelectResult> Alunos(
            [FromServices] IObterComboSelecaoAlunosQueryHandler handler,
            [FromQuery] SelectSearchParam param)
        {
            var result = handler.Execute(param.Term, param.Size, param.Selected);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("cursos")]
        public ActionResult<SelectResult> Cursos(
            [FromServices] IObterComboSelecaoCursosQueryHandler handler,
            [FromQuery] SelectSearchParam param)
        {
            var result = handler.Execute(param.Term, param.Size, param.Selected);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("usuarios")]
        public ActionResult<SelectResult> Usuarios(
            [FromServices] IObterComboSelecaoUsuariosQueryHandler handler,
            [FromQuery] SelectSearchParam param)
        {
            var result = handler.Execute(param.Term, param.Size, param.Selected);
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
