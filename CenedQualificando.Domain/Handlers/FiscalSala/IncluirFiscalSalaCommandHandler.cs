using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.FiscalSala;

public interface IIncluirFiscalSalaCommandHandler : IEditCommandHandler<FiscalSalaDto>
{
}

public class IncluirFiscalSalaCommandHandler : IIncluirFiscalSalaCommandHandler
{
    private readonly ILogger<IncluirFiscalSalaCommandHandler> Logger;
    private readonly IFiscalSalaRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public IncluirFiscalSalaCommandHandler(
        IFiscalSalaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<IncluirFiscalSalaCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(FiscalSalaDto dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirFiscalSalaCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.FiscalSala>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<FiscalSalaDto>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
