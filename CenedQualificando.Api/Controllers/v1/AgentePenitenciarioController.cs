using CenedQualificando.Domain.Handlers.AgentePenitenciario;
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
    [Route("api/v1/agentes-penitenciarios")]
    [Produces("application/json")]
    [SwaggerTag("Cadastro e Consulta de Agentes Penitenciários")]
    public class AgentePenitenciarioController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation("Inclui novo registro de agente penitenciário.")]
        public ActionResult<CommandResult> Incluir(
            [FromBody] AgentePenitenciarioViewModel vm,
            [FromServices] IIncluirAgentePenitenciarioCommandHandler handler)
        {
            var result = handler.Execute(vm);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation("Busca agente penitenciário com base no ID informado.")]
        public ActionResult<AgentePenitenciarioViewModel> Buscar(int id,
            [FromServices] IBuscarAgentePenitenciarioPorIdQueryHandler handler)
        {
            var result = handler.Execute(id);

            if (result == null)
                return NotFound(GeneralMessageResource.NenhumRecursoEncontradoParaID);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet]
        [SwaggerOperation("Busca tabela de agentes penitenciários com base nos filtros informados.")]
        public ActionResult<DataTableModel<AgentePenitenciarioViewModel>> Buscar(
            [FromQuery] AgentePenitenciarioFilter filtro,
            [FromServices] IObterDataTableAgentesPenitenciariosQueryHandler handler)
        {
            var result = handler.Execute(filtro);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation("Altera os dados do agente penitenciário com base no ID informado.")]
        public ActionResult<CommandResult> Alterar(int id,
            [FromBody] AgentePenitenciarioViewModel vm,
            [FromServices] IAlterarAgentePenitenciarioCommandHandler handler)
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
        [SwaggerOperation("Exclui o registro do agente penitenciário com base no ID informado.")]
        public ActionResult<CommandResult> Excluir(int id,
            [FromServices] IExcluirAgentePenitenciarioCommandHandler handler)
        {
            var result = handler.Execute(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
