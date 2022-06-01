using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers.UfEntrega;

public interface IAlterarUfEntregaCommandHandler : IEditCommandHandler<UfEntregaViewModel>
{
}

public class AlterarUfEntregaCommandHandler : IAlterarUfEntregaCommandHandler
{
    private readonly ILogger<AlterarUfEntregaCommandHandler> Logger;
    private readonly IUfEntregaRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public AlterarUfEntregaCommandHandler(
        IUfEntregaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<AlterarUfEntregaCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(UfEntregaViewModel dto)
    {
        Logger.LogInformation($"Iniciando handler AlterarUfEntregaCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.UfEntrega>(dto);
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
