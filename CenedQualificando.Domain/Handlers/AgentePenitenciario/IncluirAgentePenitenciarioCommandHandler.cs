using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers.AgentePenitenciario;

public interface IIncluirAgentePenitenciarioCommandHandler : IEditCommandHandler<AgentePenitenciarioViewModel>
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

    public CommandResult Execute(AgentePenitenciarioViewModel dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirAgentePenitenciarioCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.AgentePenitenciario>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<AgentePenitenciarioViewModel>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
