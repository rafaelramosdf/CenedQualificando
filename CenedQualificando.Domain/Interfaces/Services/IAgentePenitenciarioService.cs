using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IAgentePenitenciarioService : IBaseService<AgentePenitenciario, AgentePenitenciarioDto, AgentePenitenciarioFilter>
    {
    }
}
