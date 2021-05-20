using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Objects;
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
        public virtual IActionResult Incluir([FromBody] TDto model)
        {
            if (model == null)
                return NotFound();

            model.Validate();
            if (!model.IsValid)
                return BadRequest(model.Notifications);

            return Created(nameof(TEntity), Service.Incluir(model));
        }

        [HttpPut("{id:int}")]
        public virtual IActionResult Alterar(int id, [FromBody] TDto model)
        {
            if (model == null)
                return BadRequest();

            if (id != model.Id)
                return BadRequest("ID inválido");

            model.Validate();
            if (!model.IsValid)
                return BadRequest(model.Notifications);

            var vm = Service.Buscar(id);
            if (vm == null)
                return NotFound();

            Service.Alterar(model);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public virtual IActionResult Excluir(int id)
        {
            var model = Service.Buscar(id);

            if (model == null)
                return NotFound();

            Service.Excluir(model);

            return NoContent();
        }

        [HttpGet("{id:int}")]
        public virtual IActionResult Buscar(int id)
        {
            var result = Service.Buscar(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("filtros")]
        public virtual IActionResult Buscar([FromBody] DataTableModel<TDto> dataTableModel)
        {
            return Ok(Service.Buscar(dataTableModel));
        }
    }
}
