using CenedQualificando.Api.Services.Contracts;
using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CenedQualificando.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/consultas")]
    public class ConsultasController : Controller
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
