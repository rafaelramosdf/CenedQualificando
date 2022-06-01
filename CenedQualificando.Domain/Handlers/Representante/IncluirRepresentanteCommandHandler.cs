using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers.Representante;

public interface IIncluirRepresentanteCommandHandler : IEditCommandHandler<RepresentanteViewModel>
{
}

public class IncluirRepresentanteCommandHandler : IIncluirRepresentanteCommandHandler
{
    private readonly ILogger<IncluirRepresentanteCommandHandler> Logger;
    private readonly IRepresentanteRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public IncluirRepresentanteCommandHandler(
        IRepresentanteRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<IncluirRepresentanteCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(RepresentanteViewModel dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirRepresentanteCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Representante>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<RepresentanteViewModel>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
