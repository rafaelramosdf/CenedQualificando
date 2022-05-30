﻿using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.Prova;

public interface IAlterarProvaCommandHandler : IEditCommandHandler<ProvaDto>
{
}

public class AlterarProvaCommandHandler : IAlterarProvaCommandHandler
{
    private readonly ILogger<AlterarProvaCommandHandler> Logger;
    private readonly IProvaRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public AlterarProvaCommandHandler(
        IProvaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<AlterarProvaCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(ProvaDto dto)
    {
        Logger.LogInformation($"Iniciando handler AlterarProvaCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Prova>(dto);
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
