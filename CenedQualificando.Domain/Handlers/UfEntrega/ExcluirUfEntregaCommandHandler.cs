using AutoMapper;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.UfEntrega;

public interface IExcluirUfEntregaCommandHandler : IDeleteCommandHandler
{
}

public class ExcluirUfEntregaCommandHandler : IExcluirUfEntregaCommandHandler
{
    private readonly ILogger<ExcluirUfEntregaCommandHandler> Logger;
    private readonly IUfEntregaRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public ExcluirUfEntregaCommandHandler(
        IUfEntregaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<ExcluirUfEntregaCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler ExcluirUfEntregaCommandHandler");

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
