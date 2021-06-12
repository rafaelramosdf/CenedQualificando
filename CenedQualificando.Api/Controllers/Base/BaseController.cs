using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers.Base
{
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    public abstract class BaseController<TEntity, TDto, TServiceInterface> : Controller
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
        public virtual ActionResult<TDto> Incluir([FromBody] TDto model)
        {
            if (model == null)
                return BadRequest("O body request não pode ser nulo");

            model.Validate();
            if (!model.IsValid)
                return BadRequest(model.Notifications);

            return Created(nameof(TEntity), Service.Incluir(model));
        }

        [HttpPut("{id:int}")]
        public virtual ActionResult Alterar(int id, [FromBody] TDto model)
        {
            if (model == null)
                return BadRequest("O body request não pode ser nulo");

            if (id != model.Id)
                return BadRequest("ID inválido");

            model.Validate();
            if (!model.IsValid)
                return BadRequest(model.Notifications);

            var vm = Service.Buscar(id);
            if (vm == null)
                return NotFound("Nenhum recurso encontrado para o id informado");

            Service.Alterar(model);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public virtual ActionResult Excluir(int id)
        {
            var model = Service.Buscar(id);

            if (model == null)
                return NotFound("Nenhum recurso encontrado para o id informado");

            Service.Excluir(model);

            return NoContent();
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
    }
}
