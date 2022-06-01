using AutoMapper;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.GrupoDePermissao;

public interface IExcluirGrupoDePermissaoCommandHandler : IDeleteCommandHandler
{
}

public class ExcluirGrupoDePermissaoCommandHandler : IExcluirGrupoDePermissaoCommandHandler
{
    private readonly ILogger<ExcluirGrupoDePermissaoCommandHandler> Logger;
    private readonly IGrupoDePermissaoRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public ExcluirGrupoDePermissaoCommandHandler(
        IGrupoDePermissaoRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<ExcluirGrupoDePermissaoCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler ExcluirGrupoDePermissaoCommandHandler");

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
