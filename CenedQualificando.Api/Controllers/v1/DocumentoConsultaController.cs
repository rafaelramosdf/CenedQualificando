using CenedQualificando.Domain.Handlers.Matricula;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CenedQualificando.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/documentos/consultas")]
    [Produces("application/json")]
    public class DocumentoConsultaController : ControllerBase
    {
        [HttpGet("matriculas")]
        public virtual ActionResult<IEnumerable<MatriculaViewModel>> Matriculas(
            [FromServices] IObterDocumentoConsultaMatriculasQueryHandler handler,
            [FromQuery] MatriculaFilter filtro)
        {
            var result = handler.Execute(filtro);
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
