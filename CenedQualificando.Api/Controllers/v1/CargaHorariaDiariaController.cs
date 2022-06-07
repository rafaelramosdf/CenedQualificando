using CenedQualificando.Domain.Handlers.CargaHorariaDiaria;
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
    [Route("api/v1/cargas-horarias-diarias")]
    [Produces("application/json")]
    [SwaggerTag("Cadastro e Consulta de Cargas Horárias Diárias")]
    public class CargaHorariaDiariaController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation("Inclui novo registro de carga horária diária.")]
        public ActionResult<CommandResult> Incluir(
            [FromBody] CargaHorariaDiariaViewModel vm,
            [FromServices] IIncluirCargaHorariaDiariaCommandHandler handler)
        {
            var result = handler.Execute(vm);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation("Busca carga horária diária com base no ID informado.")]
        public ActionResult<CargaHorariaDiariaViewModel> Buscar(int id,
            [FromServices] IBuscarCargaHorariaDiariaPorIdQueryHandler handler)
        {
            var result = handler.Execute(id);

            if (result == null)
                return NotFound(GeneralMessageResource.NenhumRecursoEncontradoParaID);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet]
        [SwaggerOperation("Busca tabela de carga horária diária com base nos filtros informados.")]
        public ActionResult<DataTableModel<CargaHorariaDiariaViewModel>> Buscar(
            [FromQuery] CargaHorariaDiariaFilter filtro,
            [FromServices] IObterDataTableCargaHorariaDiariaQueryHandler handler)
        {
            var result = handler.Execute(filtro);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation("Altera os dados do carga horária diária com base no ID informado.")]
        public ActionResult<CommandResult> Alterar(int id, 
            [FromBody] CargaHorariaDiariaViewModel vm,
            [FromServices] IAlterarCargaHorariaDiariaCommandHandler handler)
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
        [SwaggerOperation("Exclui o registro do carga horária diária com base no ID informado.")]
        public ActionResult<CommandResult> Excluir(int id,
            [FromServices] IExcluirCargaHorariaDiariaCommandHandler handler)
        {
            var result = handler.Execute(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
