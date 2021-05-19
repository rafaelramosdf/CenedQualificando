using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/fiscais-salas")]
    public class FiscalSalaController : BaseController
    {
        [HttpGet]
        public IActionResult Listar([FromServices] IFiscalSalaService service)
        {
            return Ok(service.Listar());
        }

        [HttpPost("filtros")]
        public IActionResult Filtrar([FromServices] IFiscalSalaService service,
            [FromBody] DataTableModel<FiscalSalaDto> dataTableModel)
        {
            return Ok(service.Listar(dataTableModel));
        }
    }
}
