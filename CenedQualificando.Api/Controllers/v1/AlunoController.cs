using CenedQualificando.Domain.Handlers.Aluno;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CenedQualificando.Domain.Models.Base;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace CenedQualificando.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/alunos")]
    [Produces("application/json")]
    [SwaggerTag("Cadastro e Consulta de Alunos")]
    public class AlunoController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation("Inclui novo registro de aluno.")]
        public ActionResult<CommandResult> Incluir(
            [FromBody] AlunoViewModel vm,
            [FromServices] IIncluirAlunoCommandHandler handler)
        {
            var result = handler.Execute(vm);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation("Busca aluno com base no ID informado.")]
        public ActionResult<AlunoViewModel> Buscar(int id,
            [FromServices] IBuscarAlunoPorIdQueryHandler handler)
        {
            var result = handler.Execute(id);

            if (result == null)
                return NotFound(GeneralMessageResource.NenhumRecursoEncontradoParaID);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet]
        [SwaggerOperation("Busca tabela de alunos com base nos filtros informados.")]
        public ActionResult<DataTableModel<AlunoViewModel>> Buscar(
            [FromQuery] AlunoFilter filtro,
            [FromServices] IObterDataTableAlunosQueryHandler handler)
        {
            var result = handler.Execute(filtro);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation("Altera os dados do aluno com base no ID informado.")]
        public ActionResult<CommandResult> Alterar(int id, 
            [FromBody] AlunoViewModel vm,
            [FromServices] IAlterarAlunoCommandHandler handler)
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
        [SwaggerOperation("Exclui o registro do aluno com base no ID informado.")]
        [Authorize(Roles = "DeletarAluno")]
        public ActionResult<CommandResult> Excluir(int id,
            [FromServices] IExcluirAlunoCommandHandler handler)
        {
            var result = handler.Execute(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
