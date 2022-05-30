using AutoMapper;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.AgentePenitenciario;

public interface IExcluirAgentePenitenciarioCommandHandler : IDeleteCommandHandler
{
}

public class ExcluirAgentePenitenciarioCommandHandler : IExcluirAgentePenitenciarioCommandHandler
{
    private readonly ILogger<ExcluirAgentePenitenciarioCommandHandler> Logger;
    private readonly IAgentePenitenciarioRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public ExcluirAgentePenitenciarioCommandHandler(
        IAgentePenitenciarioRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<ExcluirAgentePenitenciarioCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler ExcluirAgentePenitenciarioCommandHandler");

        try
        {
            Repository.Remove(Repository.Get(id));
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return new CommandResult(ex);
        }
    }
}
