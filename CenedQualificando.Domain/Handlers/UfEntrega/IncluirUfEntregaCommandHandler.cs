using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.UfEntrega;

public interface IIncluirUfEntregaCommandHandler : IEditCommandHandler<UfEntregaDto>
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

    public CommandResult Execute(UfEntregaDto dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirUfEntregaCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.UfEntrega>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<UfEntregaDto>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
