﻿using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Api.Services.Contracts;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Api.Services
{
    public class AgentePenitenciarioService
        : BaseService<AgentePenitenciario, AgentePenitenciarioDto, IAgentePenitenciarioQuery, IAgentePenitenciarioRepository>, IAgentePenitenciarioService
    {
        public AgentePenitenciarioService(
            IAgentePenitenciarioQuery query,
            IAgentePenitenciarioRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper) :
            base(query, repository, unitOfWork, mapper)
        {
        }
    }
}
