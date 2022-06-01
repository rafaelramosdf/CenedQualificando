using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers.Usuario;

public interface IIncluirUsuarioCommandHandler : IEditCommandHandler<UsuarioViewModel>
{
}

public class IncluirUsuarioCommandHandler : IIncluirUsuarioCommandHandler
{
    private readonly ILogger<IncluirUsuarioCommandHandler> Logger;
    private readonly IUsuarioRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public IncluirUsuarioCommandHandler(
        IUsuarioRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<IncluirUsuarioCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(UsuarioViewModel dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirUsuarioCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Usuario>(dto);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<UsuarioViewModel>(entity));
        }
        catch (Exception ex)
        {
            return new CommandResult(ex, dto);
        }
    }
}
