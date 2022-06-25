using CenedQualificando.Domain.Handlers.Usuario;
using Microsoft.AspNetCore.Mvc;
using CenedQualificando.Domain.Models.Dtos;
using Microsoft.AspNetCore.Http;
using CenedQualificando.Api.Helpers;
using Swashbuckle.AspNetCore.Annotations;

namespace CenedQualificando.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/acessos")]
    [Produces("application/json")]
    [SwaggerTag("Rotas para autenticação e controle de acessos de usuaários de sistema")]
    public class AcessoController : ControllerBase
    {
        [HttpPost("autenticar")]
        public ActionResult<TokenAutenticacaoDto> Autenticar(
            [FromBody] AutenticacaoUsuarioDto dto,
            [FromServices] IAutenticarUsuarioCommandHandler handler)
        {
            var result = handler.Execute(dto);

            if (result == null)
                return StatusCode(StatusCodes.Status401Unauthorized);

            var tokenDto = TokenHelper.GenerateToken(result);

            return StatusCode(StatusCodes.Status200OK, tokenDto);
        }
    }
}
