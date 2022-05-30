﻿using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.Curso;

public interface IIncluirCursoCommandHandler : IEditCommandHandler<CursoDto>
{
}

public class IncluirCursoCommandHandler : IIncluirCursoCommandHandler
{
    private readonly ILogger<IncluirCursoCommandHandler> Logger;
    private readonly ICursoRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public IncluirCursoCommandHandler(
        ICursoRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<IncluirCursoCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(CursoDto dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirCursoCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Curso>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<CursoDto>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
