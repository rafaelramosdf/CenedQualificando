using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Api.Services.Contracts;
using CenedQualificando.CrossCutting.Dtos;
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
