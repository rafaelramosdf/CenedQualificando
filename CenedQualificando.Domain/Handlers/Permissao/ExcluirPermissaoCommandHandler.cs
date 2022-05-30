using AutoMapper;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.Permissao;

public interface IExcluirPermissaoCommandHandler : IDeleteCommandHandler
{
}

public class ExcluirPermissaoCommandHandler : IExcluirPermissaoCommandHandler
{
    private readonly ILogger<ExcluirPermissaoCommandHandler> Logger;
    private readonly IPermissaoRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public ExcluirPermissaoCommandHandler(
        IPermissaoRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<ExcluirPermissaoCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler ExcluirPermissaoCommandHandler");

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
