using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Api.Services.Contracts;
using CenedQualificando.CrossCutting.Dtos;
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
