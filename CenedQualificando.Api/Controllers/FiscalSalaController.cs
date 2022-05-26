using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/fiscais-salas")]
    public class FiscalSalaController : BaseController<FiscalSala, FiscalSalaDto, FiscalSalaFilter, IFiscalSalaService>
    {
        public FiscalSalaController(IFiscalSalaService service)
        : base(service)
        {
        }
    }
}
