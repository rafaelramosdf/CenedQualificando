using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.FiscalSala;

public interface IIncluirFiscalSalaCommandHandler : IEditCommandHandler<FiscalSalaViewModel>
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

    public CommandResult Execute(FiscalSalaViewModel dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirFiscalSalaCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.FiscalSala>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<FiscalSalaViewModel>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
