using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Api.Services.Contracts;
using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/cargas-horarias-diarias")]
    public class CargaHorariaDiariaController : BaseController<CargaHorariaDiaria, CargaHorariaDiariaDto, ICargaHorariaDiariaService>
    {
        public CargaHorariaDiariaController(ICargaHorariaDiariaService service)
        : base(service)
        {
        }
    }
}
