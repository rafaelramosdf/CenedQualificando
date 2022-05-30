using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.Prova;

public interface IIncluirProvaCommandHandler : IEditCommandHandler<ProvaDto>
{
}

public class IncluirProvaCommandHandler : IIncluirProvaCommandHandler
{
    private readonly ILogger<IncluirProvaCommandHandler> Logger;
    private readonly IProvaRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public IncluirProvaCommandHandler(
        IProvaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<IncluirProvaCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(ProvaDto dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirProvaCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Prova>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<ProvaDto>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
