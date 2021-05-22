using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/uf-entregas")]
    public class UfEntregaController : BaseController<UfEntrega, UfEntregaDto, IUfEntregaService>
    {
        public UfEntregaController(IUfEntregaService service)
        : base(service)
        {
        }
    }
}
