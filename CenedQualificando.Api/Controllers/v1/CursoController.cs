using CenedQualificando.Domain.Handlers.Curso;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CenedQualificando.Domain.Models.Base;
using Swashbuckle.AspNetCore.Annotations;

namespace CenedQualificando.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/cursos")]
    [Produces("application/json")]
    [SwaggerTag("Cadastro e Consulta de Cursos CENED")]
    public class CursoController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation("Inclui novo registro de curso.")]
        public ActionResult<CommandResult> Incluir(
            [FromBody] CursoViewModel vm,
            [FromServices] IIncluirCursoCommandHandler handler)
        {
            var result = handler.Execute(vm);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation("Busca curso com base no ID informado.")]
        public ActionResult<CursoViewModel> Buscar(int id,
            [FromServices] IBuscarCursoPorIdQueryHandler handler)
        {
            var result = handler.Execute(id);

            if (result == null)
                return NotFound(GeneralMessageResource.NenhumRecursoEncontradoParaID);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet]
        [SwaggerOperation("Busca tabela de cursos com base nos filtros informados.")]
        public ActionResult<DataTableModel<CursoViewModel>> Buscar(
            [FromQuery] CursoFilter filtro,
            [FromServices] IObterDataTableCursosQueryHandler handler)
        {
            var result = handler.Execute(filtro);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation("Altera os dados do curso com base no ID informado.")]
        public ActionResult<CommandResult> Alterar(int id, 
            [FromBody] CursoViewModel vm,
            [FromServices] IAlterarCursoCommandHandler handler)
        {
            if (id != vm.Id)
            {
                var commandResult = new CommandResult(StatusCodes.Status400BadRequest);
                commandResult.SetError(ValidationMessageResource.IdInvalido);
                return StatusCode(commandResult.StatusCode, commandResult);
            }

            var result = handler.Execute(vm);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation("Exclui o registro do curso com base no ID informado.")]
        public ActionResult<CommandResult> Excluir(int id,
            [FromServices] IExcluirCursoCommandHandler handler)
        {
            var result = handler.Execute(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
