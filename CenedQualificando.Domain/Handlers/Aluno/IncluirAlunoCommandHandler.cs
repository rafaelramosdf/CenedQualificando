using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.Aluno;

public interface IIncluirAlunoCommandHandler : IEditCommandHandler<AlunoDto>
{
}

public class IncluirAlunoCommandHandler : IIncluirAlunoCommandHandler
{
    private readonly ILogger<IncluirAlunoCommandHandler> Logger;
    private readonly IAlunoRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public IncluirAlunoCommandHandler(
        IAlunoRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<IncluirAlunoCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(AlunoDto dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirAlunoCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Aluno>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<AlunoDto>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
