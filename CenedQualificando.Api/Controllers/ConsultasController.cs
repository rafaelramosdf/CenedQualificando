using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CenedQualificando.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/consultas")]
    public class ConsultasController : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpPost("matriculas")]
        public virtual ActionResult<IEnumerable<MatriculaDto>> Matriculas(
            [FromServices] IMatriculaService service,
            [FromBody] MatriculaFilter filtro)
        {
            return Ok(service.Filtrar(filtro));
        }
    }
}
