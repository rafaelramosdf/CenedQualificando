using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/penitenciarias")]
    public class PenitenciariaController : BaseController<Penitenciaria, PenitenciariaDto, IPenitenciariaService>
    {
        public PenitenciariaController(IPenitenciariaService service)
        : base(service)
        {
        }
    }
}
