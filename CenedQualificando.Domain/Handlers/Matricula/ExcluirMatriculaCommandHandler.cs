using AutoMapper;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.Matricula;

public interface IExcluirMatriculaCommandHandler : IDeleteCommandHandler
{
}

public class ExcluirMatriculaCommandHandler : IExcluirMatriculaCommandHandler
{
    private readonly ILogger<ExcluirMatriculaCommandHandler> Logger;
    private readonly IMatriculaRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public ExcluirMatriculaCommandHandler(
        IMatriculaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<ExcluirMatriculaCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler ExcluirMatriculaCommandHandler");

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
