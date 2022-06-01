using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers.CargaHorariaDiaria;

public interface IIncluirCargaHorariaDiariaCommandHandler : IEditCommandHandler<CargaHorariaDiariaViewModel>
{
}

public class IncluirCargaHorariaDiariaCommandHandler : IIncluirCargaHorariaDiariaCommandHandler
{
    private readonly ILogger<IncluirCargaHorariaDiariaCommandHandler> Logger;
    private readonly ICargaHorariaDiariaRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public IncluirCargaHorariaDiariaCommandHandler(
        ICargaHorariaDiariaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<IncluirCargaHorariaDiariaCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(CargaHorariaDiariaViewModel dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirCargaHorariaDiariaCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.CargaHorariaDiaria>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<CargaHorariaDiariaViewModel>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
