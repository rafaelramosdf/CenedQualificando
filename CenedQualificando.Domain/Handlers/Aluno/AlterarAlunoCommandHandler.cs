using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers.Aluno;

public interface IAlterarAlunoCommandHandler : IEditCommandHandler<AlunoViewModel>
{
}

public class AlterarAlunoCommandHandler : IAlterarAlunoCommandHandler
{
    private readonly ILogger<AlterarAlunoCommandHandler> Logger;
    private readonly IAlunoRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public AlterarAlunoCommandHandler(
        IAlunoRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<AlterarAlunoCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(AlunoViewModel dto)
    {
        Logger.LogInformation($"Iniciando handler AlterarAlunoCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Aluno>(dto);
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
