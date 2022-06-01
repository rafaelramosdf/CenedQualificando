using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers.Matricula;

public interface IIncluirMatriculaCommandHandler : IEditCommandHandler<MatriculaViewModel>
{
}

public class IncluirMatriculaCommandHandler : IIncluirMatriculaCommandHandler
{
    private readonly ILogger<IncluirMatriculaCommandHandler> Logger;
    private readonly IMatriculaRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public IncluirMatriculaCommandHandler(
        IMatriculaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<IncluirMatriculaCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(MatriculaViewModel dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirMatriculaCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Matricula>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<MatriculaViewModel>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
