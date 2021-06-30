using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Api.Services.Contracts;
using CenedQualificando.CrossCutting.Dtos;
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
