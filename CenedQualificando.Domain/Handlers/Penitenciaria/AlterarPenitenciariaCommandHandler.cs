﻿using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers.Penitenciaria;

public interface IAlterarPenitenciariaCommandHandler : IEditCommandHandler<PenitenciariaViewModel>
{
}

public class AlterarPenitenciariaCommandHandler : IAlterarPenitenciariaCommandHandler
{
    private readonly ILogger<AlterarPenitenciariaCommandHandler> Logger;
    private readonly IPenitenciariaRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public AlterarPenitenciariaCommandHandler(
        IPenitenciariaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<AlterarPenitenciariaCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(PenitenciariaViewModel dto)
    {
        Logger.LogInformation($"Iniciando handler AlterarPenitenciariaCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Penitenciaria>(dto);
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
