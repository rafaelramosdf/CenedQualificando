using AutoMapper;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.CargaHorariaDiaria;

public interface IExcluirCargaHorariaDiariaCommandHandler : IDeleteCommandHandler
{
}

public class ExcluirCargaHorariaDiariaCommandHandler : IExcluirCargaHorariaDiariaCommandHandler
{
    private readonly ILogger<ExcluirCargaHorariaDiariaCommandHandler> Logger;
    private readonly ICargaHorariaDiariaRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public ExcluirCargaHorariaDiariaCommandHandler(
        ICargaHorariaDiariaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<ExcluirCargaHorariaDiariaCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler ExcluirCargaHorariaDiariaCommandHandler");

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
