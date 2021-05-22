using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/matriculas")]
    public class MatriculaController : BaseController<Matricula, MatriculaDto, IMatriculaService>
    {
        public MatriculaController(IMatriculaService service)
        : base(service)
        {
        }
    }
}
