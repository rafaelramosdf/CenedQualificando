using AutoMapper;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.Usuario;

public interface IExcluirUsuarioCommandHandler : IDeleteCommandHandler
{
}

public class ExcluirUsuarioCommandHandler : IExcluirUsuarioCommandHandler
{
    private readonly ILogger<ExcluirUsuarioCommandHandler> Logger;
    private readonly IUsuarioRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public ExcluirUsuarioCommandHandler(
        IUsuarioRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<ExcluirUsuarioCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler ExcluirUsuarioCommandHandler");

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
