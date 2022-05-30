using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.AgentePenitenciario;

public interface IAlterarAgentePenitenciarioCommandHandler : IEditCommandHandler<AgentePenitenciarioDto>
{
}

public class AlterarAgentePenitenciarioCommandHandler : IAlterarAgentePenitenciarioCommandHandler
{
    private readonly ILogger<AlterarAgentePenitenciarioCommandHandler> Logger;
    private readonly IAgentePenitenciarioRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public AlterarAgentePenitenciarioCommandHandler(
        IAgentePenitenciarioRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<AlterarAgentePenitenciarioCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(AgentePenitenciarioDto dto)
    {
        Logger.LogInformation($"Iniciando handler AlterarAgentePenitenciarioEditCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.AgentePenitenciario>(dto);
            Repository.Update(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
