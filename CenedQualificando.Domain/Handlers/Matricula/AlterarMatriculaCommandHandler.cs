﻿using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.Matricula;

public interface IAlterarMatriculaCommandHandler : IEditCommandHandler<MatriculaDto>
{
}

public class AlterarMatriculaCommandHandler : IAlterarMatriculaCommandHandler
{
    private readonly ILogger<AlterarMatriculaCommandHandler> Logger;
    private readonly IMatriculaRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public AlterarMatriculaCommandHandler(
        IMatriculaRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<AlterarMatriculaCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(MatriculaDto dto)
    {
        Logger.LogInformation($"Iniciando handler AlterarMatriculaCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Matricula>(dto);
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
