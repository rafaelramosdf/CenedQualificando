using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers.Usuario;

public interface IAlterarUsuarioCommandHandler : IEditCommandHandler<UsuarioViewModel>
{
}

public class AlterarUsuarioCommandHandler : IAlterarUsuarioCommandHandler
{
    private readonly ILogger<AlterarUsuarioCommandHandler> Logger;
    private readonly IUsuarioRepository Repository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public AlterarUsuarioCommandHandler(
        IUsuarioRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<AlterarUsuarioCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(UsuarioViewModel dto)
    {
        Logger.LogInformation($"Iniciando handler AlterarUsuarioCommandHandler");

        try
        {
            var entity = Mapper.Map<Models.Entities.Usuario>(dto);
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
