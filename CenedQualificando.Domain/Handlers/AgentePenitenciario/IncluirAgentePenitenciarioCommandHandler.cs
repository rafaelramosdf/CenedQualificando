using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.AgentePenitenciario;

public interface IIncluirAgentePenitenciarioCommandHandler : IEditCommandHandler<AgentePenitenciarioDto>
{
}

public class IncluirAgentePenitenciarioCommandHandler : IIncluirAgentePenitenciarioCommandHandler
{
    private readonly ILogger<IncluirAgentePenitenciarioCommandHandler> Logger;
    private readonly IAgentePenitenciarioRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public IncluirAgentePenitenciarioCommandHandler(
        IAgentePenitenciarioRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<IncluirAgentePenitenciarioCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(AgentePenitenciarioDto dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirAgentePenitenciarioCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.AgentePenitenciario>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<AgentePenitenciarioDto>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
