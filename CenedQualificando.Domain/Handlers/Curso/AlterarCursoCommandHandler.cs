using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.Curso;

public interface IAlterarCursoCommandHandler : IEditCommandHandler<CursoDto>
{
}

public class AlterarCursoCommandHandler : IAlterarCursoCommandHandler
{
    private readonly ILogger<AlterarCursoCommandHandler> Logger;
    private readonly ICursoRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public AlterarCursoCommandHandler(
        ICursoRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<AlterarCursoCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(CursoDto dto)
    {
        Logger.LogInformation($"Iniciando handler AlterarCursoCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Curso>(dto);
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
