using CenedQualificando.Domain.Handlers.Matricula;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/matriculas")]
    [Produces("application/json")]
    public class MatriculaController : ControllerBase
    {
        [HttpPost]
        public ActionResult<CommandResult> Incluir(
            [FromBody] MatriculaViewModel vm,
            [FromServices] IIncluirMatriculaCommandHandler handler)
        {
            var result = handler.Execute(vm);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<MatriculaViewModel> Buscar(int id,
            [FromServices] IBuscarMatriculaPorIdQueryHandler handler)
        {
            var result = handler.Execute(id);

            if (result == null)
                return NotFound(GeneralMessageResource.NenhumRecursoEncontradoParaID);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet]
        public ActionResult<DataTableModel<MatriculaViewModel>> Buscar(
            [FromQuery] MatriculaFilter filtro,
            [FromServices] IObterDataTableMatriculasQueryHandler handler)
        {
            var result = handler.Execute(filtro);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CommandResult> Alterar(int id, 
            [FromBody] MatriculaViewModel vm,
            [FromServices] IAlterarMatriculaCommandHandler handler)
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
        public ActionResult<CommandResult> Excluir(int id,
            [FromServices] IExcluirMatriculaCommandHandler handler)
        {
            var result = handler.Execute(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
