using CenedQualificando.Domain.Handlers.Representante;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/representantes")]
    [Produces("application/json")]
    public class RepresentanteController : ControllerBase
    {
        [HttpPost]
        public ActionResult<CommandResult> Incluir(
            [FromBody] RepresentanteDto vm,
            [FromServices] IIncluirRepresentanteCommandHandler handler)
        {
            var result = handler.Execute(vm);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<RepresentanteDto> Buscar(int id,
            [FromServices] IBuscarRepresentantePorIdQueryHandler handler)
        {
            var result = handler.Execute(id);

            if (result == null)
                return NotFound(GeneralMessageResource.NenhumRecursoEncontradoParaID);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet]
        public ActionResult<DataTableModel<RepresentanteDto>> Buscar(
            [FromQuery] RepresentanteFilter filtro,
            [FromServices] IObterDataTableRepresentantesQueryHandler handler)
        {
            var result = handler.Execute(filtro);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CommandResult> Alterar(int id, 
            [FromBody] RepresentanteDto vm,
            [FromServices] IAlterarRepresentanteCommandHandler handler)
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
            [FromServices] IExcluirRepresentanteCommandHandler handler)
        {
            var result = handler.Execute(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
