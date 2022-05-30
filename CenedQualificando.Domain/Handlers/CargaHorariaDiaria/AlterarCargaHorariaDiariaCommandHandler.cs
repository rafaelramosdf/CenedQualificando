using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.CargaHorariaDiaria;

public interface IAlterarCargaHorariaDiariaCommandHandler : IEditCommandHandler<CargaHorariaDiariaDto>
{
}

public class AlterarCargaHorariaDiariaCommandHandler : IAlterarCargaHorariaDiariaCommandHandler
{
    private readonly ILogger<AlterarCargaHorariaDiariaCommandHandler> Logger;
    private readonly ICargaHorariaDiariaRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public AlterarCargaHorariaDiariaCommandHandler(
        ICargaHorariaDiariaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<AlterarCargaHorariaDiariaCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(CargaHorariaDiariaDto dto)
    {
        Logger.LogInformation($"Iniciando handler AlterarCargaHorariaDiariaCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.CargaHorariaDiaria>(dto);
            Repository.Update(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
