using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers.Representante;

public interface IAlterarRepresentanteCommandHandler : IEditCommandHandler<RepresentanteViewModel>
{
}

public class AlterarRepresentanteCommandHandler : IAlterarRepresentanteCommandHandler
{
    private readonly ILogger<AlterarRepresentanteCommandHandler> Logger;
    private readonly IRepresentanteRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public AlterarRepresentanteCommandHandler(
        IRepresentanteRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<AlterarRepresentanteCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(RepresentanteViewModel dto)
    {
        Logger.LogInformation($"Iniciando handler AlterarRepresentanteCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Representante>(dto);
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
