using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers.Permissao;

public interface IAlterarPermissaoCommandHandler : IEditCommandHandler<PermissaoViewModel>
{
}

public class AlterarPermissaoCommandHandler : IAlterarPermissaoCommandHandler
{
    private readonly ILogger<AlterarPermissaoCommandHandler> Logger;
    private readonly IPermissaoRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public AlterarPermissaoCommandHandler(
        IPermissaoRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<AlterarPermissaoCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(PermissaoViewModel dto)
    {
        Logger.LogInformation($"Iniciando handler AlterarPermissaoCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Permissao>(dto);
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
