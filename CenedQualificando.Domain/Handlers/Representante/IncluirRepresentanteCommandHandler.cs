using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.Representante;

public interface IIncluirRepresentanteCommandHandler : IEditCommandHandler<RepresentanteDto>
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

    public CommandResult Execute(RepresentanteDto dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirRepresentanteCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Representante>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<RepresentanteDto>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
