using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/agentes-penitenciarios")]
    public class AgentePenitenciarioController : BaseController<AgentePenitenciario, AgentePenitenciarioDto, AgentePenitenciarioFilter, IAgentePenitenciarioService>
    {
        public AgentePenitenciarioController(IAgentePenitenciarioService service)
        : base(service)
        {
        }
    }
}
