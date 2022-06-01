using CenedQualificando.Domain.Handlers.UfEntrega;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/uf-entregas")]
    [Produces("application/json")]
    public class UfEntregaController : ControllerBase
    {
        [HttpPost]
        public ActionResult<CommandResult> Incluir(
            [FromBody] UfEntregaViewModel vm,
            [FromServices] IIncluirUfEntregaCommandHandler handler)
        {
            var result = handler.Execute(vm);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<UfEntregaViewModel> Buscar(int id,
            [FromServices] IBuscarUfEntregaPorIdQueryHandler handler)
        {
            var result = handler.Execute(id);

            if (result == null)
                return NotFound(GeneralMessageResource.NenhumRecursoEncontradoParaID);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet]
        public ActionResult<DataTableModel<UfEntregaViewModel>> Buscar(
            [FromQuery] UfEntregaFilter filtro,
            [FromServices] IObterDataTableUfEntregasQueryHandler handler)
        {
            var result = handler.Execute(filtro);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CommandResult> Alterar(int id, 
            [FromBody] UfEntregaViewModel vm,
            [FromServices] IAlterarUfEntregaCommandHandler handler)
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
            [FromServices] IExcluirUfEntregaCommandHandler handler)
        {
            var result = handler.Execute(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
