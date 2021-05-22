using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/representantes")]
    public class RepresentanteController : BaseController<Representante, RepresentanteDto, IRepresentanteService>
    {
        public RepresentanteController(IRepresentanteService service)
        : base(service)
        {
        }
    }
}
