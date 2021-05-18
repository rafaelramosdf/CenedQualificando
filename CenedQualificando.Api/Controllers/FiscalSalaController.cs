using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Api.Models;
using CenedQualificando.Api.Models.Base;
using CenedQualificando.Api.Services.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            [FromBody] DataTableModel<FiscalSalaModel> dataTableModel)
        {
            return Ok(service.Listar(dataTableModel));
        }
    }
}
