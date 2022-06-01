using AutoMapper;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.Representante;

public interface IExcluirRepresentanteCommandHandler : IDeleteCommandHandler
{
}

public class ExcluirRepresentanteCommandHandler : IExcluirRepresentanteCommandHandler
{
    private readonly ILogger<ExcluirRepresentanteCommandHandler> Logger;
    private readonly IRepresentanteRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public ExcluirRepresentanteCommandHandler(
        IRepresentanteRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<ExcluirRepresentanteCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler ExcluirRepresentanteCommandHandler");

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
