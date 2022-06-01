using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers.UfEntrega;

public interface IIncluirUfEntregaCommandHandler : IEditCommandHandler<UfEntregaViewModel>
{
}

public class IncluirUfEntregaCommandHandler : IIncluirUfEntregaCommandHandler
{
    private readonly ILogger<IncluirUfEntregaCommandHandler> Logger;
    private readonly IUfEntregaRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public IncluirUfEntregaCommandHandler(
        IUfEntregaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<IncluirUfEntregaCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(UfEntregaViewModel dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirUfEntregaCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.UfEntrega>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<UfEntregaViewModel>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
