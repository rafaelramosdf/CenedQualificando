using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Api.Services.Contracts;
using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/cursos")]
    public class CursoController : BaseController<Curso, CursoDto, ICursoService>
    {
        public CursoController(ICursoService service)
        : base(service)
        {
        }
    }
}
