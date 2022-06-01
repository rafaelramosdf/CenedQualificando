using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers.Penitenciaria;

public interface IIncluirPenitenciariaCommandHandler : IEditCommandHandler<PenitenciariaViewModel>
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

    public CommandResult Execute(PenitenciariaViewModel dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirPenitenciariaCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Penitenciaria>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<PenitenciariaViewModel>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
