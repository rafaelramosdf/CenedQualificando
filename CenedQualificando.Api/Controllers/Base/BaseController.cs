using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CenedQualificando.Api.Controllers.Base
{
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    public abstract class BaseController<TEntity, TDto, TServiceInterface> : Microsoft.AspNetCore.Mvc.Controller
        where TEntity : Entity, new()
        where TDto : Dto<TEntity>, new()
        where TServiceInterface : IBaseService<TEntity, TDto>
    {
        protected readonly TServiceInterface Service;

        protected BaseController(TServiceInterface service)
        {
            Service = service;
        }

        [HttpPost]
        public virtual CommandResult Incluir([FromBody] TDto vm)
        {
            return Service.Incluir(vm);
        }

        [HttpPut("{id:int}")]
        public virtual CommandResult Alterar(int id, [FromBody] TDto vm)
        {
            if (id != vm.Id)
            {
                var commandResult = new CommandResult();
                commandResult.SetError("ID inválido");
                return commandResult;
            }

            return Service.Alterar(vm);
        }

        [HttpDelete("{id:int}")]
        public virtual CommandResult Excluir(int id)
        {
            return Service.Excluir(id);
        }

        [HttpGet("{id:int}")]
        public virtual ActionResult<TDto> Buscar(int id)
        {
            var result = Service.Buscar(id);

            if (result == null)
                return NotFound("Nenhum recurso encontrado para o id informado");

            return Ok(result);
        }

        [HttpPost("filtros")]
        public virtual ActionResult<DataTableModel<TDto>> Buscar([FromBody] DataTableModel<TDto> dataTableModel)
        {
            return Ok(Service.Buscar(dataTableModel));
        }



        protected CommandResult ValidarModelo(TDto vm = null)
        {
            if (ModelState.IsValid)
            {
                return new CommandResult(StatusCodes.Status200OK);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(s => s.Errors).Select(s => s.ErrorMessage).ToList();
                var commandResult = new CommandResult(StatusCodes.Status400BadRequest, vm);
                commandResult.SetErrors(errors);
                return commandResult;
            }
        }
    }
}
