using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/permissoes")]
    public class PermissaoController : BaseController<Permissao, PermissaoDto, PermissaoFilter, IPermissaoService>
    {
        public PermissaoController(IPermissaoService service)
        : base(service)
        {
        }
    }
}
