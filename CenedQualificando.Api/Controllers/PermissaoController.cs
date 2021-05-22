using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/permissoes")]
    public class PermissaoController : BaseController<Permissao, PermissaoDto, IPermissaoService>
    {
        public PermissaoController(IPermissaoService service)
        : base(service)
        {
        }
    }
}
