using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.Penitenciaria;

public interface IIncluirPenitenciariaCommandHandler : IEditCommandHandler<PenitenciariaDto>
{
}

public class IncluirPenitenciariaCommandHandler : IIncluirPenitenciariaCommandHandler
{
    private readonly ILogger<IncluirPenitenciariaCommandHandler> Logger;
    private readonly IPenitenciariaRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public IncluirPenitenciariaCommandHandler(
        IPenitenciariaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<IncluirPenitenciariaCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(PenitenciariaDto dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirPenitenciariaCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Penitenciaria>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<PenitenciariaDto>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
