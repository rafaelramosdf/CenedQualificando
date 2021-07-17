using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Api.Services
{
    public class AgentePenitenciarioService
        : BaseService<AgentePenitenciario, AgentePenitenciarioDto, IAgentePenitenciarioQuery, IAgentePenitenciarioRepository>, IAgentePenitenciarioService
    {
        public AgentePenitenciarioService(
            IAgentePenitenciarioQuery query,
            IAgentePenitenciarioRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<AgentePenitenciarioService> log) : 
            base(query, repository, unitOfWork, mapper, log)
        {
        }
    }
}
