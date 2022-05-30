using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.UfEntrega;

public interface IAlterarUfEntregaCommandHandler : IEditCommandHandler<UfEntregaDto>
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

    public CommandResult Execute(UfEntregaDto dto)
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
