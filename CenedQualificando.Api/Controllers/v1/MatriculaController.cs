using CenedQualificando.Domain.Handlers.Matricula;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CenedQualificando.Domain.Models.Base;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace CenedQualificando.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/matriculas")]
    [Produces("application/json")]
    [SwaggerTag("Cadastro e Consulta de Matrículas")]
    public class MatriculaController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation("Inclui novo registro de matrícula.")]
        public ActionResult<CommandResult> Incluir(
            [FromBody] MatriculaViewModel vm,
            [FromServices] IIncluirMatriculaCommandHandler handler)
        {
            var result = handler.Execute(vm);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation("Busca matrícula com base no ID informado.")]
        public ActionResult<MatriculaViewModel> Buscar(int id,
            [FromServices] IBuscarMatriculaPorIdQueryHandler handler)
        {
            var result = handler.Execute(id);

            if (result == null)
                return NotFound(GeneralMessageResource.NenhumRecursoEncontradoParaID);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet]
        [SwaggerOperation("Busca tabela de matrículas com base nos filtros informados.")]
        public async Task<ActionResult<DataTableModel<MatriculaViewModel>>> Buscar(
            [FromQuery] MatriculaFilter filtro,
            [FromServices] IObterDataTableMatriculasQueryHandler handler)
        {
            var result = await handler.Execute(filtro);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation("Altera os dados do matrícula com base no ID informado.")]
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
        [SwaggerOperation("Exclui o registro do matrícula com base no ID informado.")]
        public ActionResult<CommandResult> Excluir(int id,
            [FromServices] IExcluirMatriculaCommandHandler handler)
        {
            var result = handler.Execute(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
