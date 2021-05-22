using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : BaseController<Usuario, UsuarioDto, IUsuarioService>
    {
        public UsuarioController(IUsuarioService service)
        : base(service)
        {
        }
    }
}
