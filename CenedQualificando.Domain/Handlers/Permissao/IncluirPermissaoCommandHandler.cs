using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CenedQualificando.Domain.Handlers.Permissao;

public interface IIncluirPermissaoCommandHandler : IEditCommandHandler<PermissaoDto>
{
}

public class IncluirPermissaoCommandHandler : IIncluirPermissaoCommandHandler
{
    private readonly ILogger<IncluirPermissaoCommandHandler> Logger;
    private readonly IPermissaoRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public IncluirPermissaoCommandHandler(
        IPermissaoRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<IncluirPermissaoCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(PermissaoDto dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirPermissaoCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Permissao>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<PermissaoDto>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
