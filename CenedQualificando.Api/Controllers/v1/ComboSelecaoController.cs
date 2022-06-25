using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Handlers.Aluno;
using CenedQualificando.Domain.Handlers.Curso;
using CenedQualificando.Domain.Handlers.Penitenciaria;
using CenedQualificando.Domain.Handlers.Usuario;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Models.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CenedQualificando.Api.Controllers.v1
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/combos")]
    [SwaggerTag("Lista de items para componentes de seleção (Select/AutoComplete)")]
    public class ComboSelecaoController : Controller
    {
        [HttpGet("penitenciarias")]
        public ActionResult<SelectResult> Penitenciarias(
            [FromServices] IObterComboSelecaoPenitenciariasQueryHandler handler,
            [FromQuery] SelectSearchParam param)
        {
            var result = handler.Execute(param.Term, param.Size, param.Selected);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("filtros/penitenciarias")]
        public ActionResult<SelectResult> Penitenciarias(
            [FromServices] IObterComboSelecaoPenitenciariasComFiltroQueryHandler handler,
            [FromQuery] PenitenciariaFilter param)
        {
            var result = handler.Execute(param);
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

        [HttpGet("status-curso")]
        public ActionResult<SelectResult> StatusCurso([FromQuery] SelectSearchParam param)
        {
            return Ok(ObterListaEnumeradores<StatusCursoEnum>(param));
        }

        private IEnumerable<SelectResult> ObterListaEnumeradores<TEnum>(SelectSearchParam param)
            where TEnum : struct, Enum
        {
            var list = new List<SelectResult>();

            list = !string.IsNullOrEmpty(param.Term)
                ? Enum.GetValues<TEnum>().ToList()
                    .Where(x => x.EnumDescription().Contains(param.Term))
                    .Select(s => new SelectResult { Id = s.ToInt32(), Text = s.EnumDescription() })
                    .ToList()
                : Enum.GetValues<TEnum>()
                    .Select(s => new SelectResult { Id = s.ToInt32(), Text = s.EnumDescription() })
                    .ToList();

            return list;
        }
    }
}
