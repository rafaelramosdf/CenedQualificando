using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Api.Services.Contracts;
using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/provas")]
    public class ProvaController : BaseController<Prova, ProvaDto, IProvaService>
    {
        public ProvaController(IProvaService service)
        : base(service)
        {
        }
    }
}
