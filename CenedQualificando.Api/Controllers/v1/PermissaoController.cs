using CenedQualificando.Domain.Handlers.Permissao;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/permissoes")]
    [Produces("application/json")]
    public class PermissaoController : ControllerBase
    {
        [HttpPost]
        public ActionResult<CommandResult> Incluir(
            [FromBody] PermissaoViewModel vm,
            [FromServices] IIncluirPermissaoCommandHandler handler)
        {
            var result = handler.Execute(vm);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<PermissaoViewModel> Buscar(int id,
            [FromServices] IBuscarPermissaoPorIdQueryHandler handler)
        {
            var result = handler.Execute(id);

            if (result == null)
                return NotFound(GeneralMessageResource.NenhumRecursoEncontradoParaID);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet]
        public ActionResult<DataTableModel<PermissaoViewModel>> Buscar(
            [FromQuery] PermissaoFilter filtro,
            [FromServices] IObterDataTablePermissaosQueryHandler handler)
        {
            var result = handler.Execute(filtro);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CommandResult> Alterar(int id, 
            [FromBody] PermissaoViewModel vm,
            [FromServices] IAlterarPermissaoCommandHandler handler)
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
            [FromServices] IExcluirPermissaoCommandHandler handler)
        {
            var result = handler.Execute(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
