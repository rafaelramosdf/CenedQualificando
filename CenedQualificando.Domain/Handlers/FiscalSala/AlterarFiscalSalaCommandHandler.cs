using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.FiscalSala;

public interface IAlterarFiscalSalaCommandHandler : IEditCommandHandler<FiscalSalaDto>
{
}

public class AlterarFiscalSalaCommandHandler : IAlterarFiscalSalaCommandHandler
{
    private readonly ILogger<AlterarFiscalSalaCommandHandler> Logger;
    private readonly IFiscalSalaRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public AlterarFiscalSalaCommandHandler(
        IFiscalSalaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<AlterarFiscalSalaCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(FiscalSalaDto dto)
    {
        Logger.LogInformation($"Iniciando handler AlterarFiscalSalaCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.FiscalSala>(dto);
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
