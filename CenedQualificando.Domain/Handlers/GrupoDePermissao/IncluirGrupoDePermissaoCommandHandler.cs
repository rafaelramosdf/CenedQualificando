using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace CenedQualificando.Domain.Handlers.GrupoDePermissao;

public interface IIncluirGrupoDePermissaoCommandHandler : IEditCommandHandler<GrupoDePermissaoDto>
{
}

public class IncluirGrupoDePermissaoCommandHandler : IIncluirGrupoDePermissaoCommandHandler
{
    private readonly ILogger<IncluirGrupoDePermissaoCommandHandler> Logger;
    private readonly IGrupoDePermissaoRepository Repository;
    private readonly IPermissaoRepository PermissaoRepository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public IncluirGrupoDePermissaoCommandHandler(
        IGrupoDePermissaoRepository repository,
        IPermissaoRepository permissaoRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<IncluirGrupoDePermissaoCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        PermissaoRepository = permissaoRepository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public CommandResult Execute(GrupoDePermissaoDto dto)
    {
        Logger.LogInformation($"Iniciando handler IncluirGrupoDePermissaoCommandHandler");

        try
        {
            var commandResult = new CommandResult();

            UnitOfWork.BeginTransaction();

            var grupoPermissao = Mapper.Map<Models.Entities.GrupoDePermissao>(dto);
            var permissoes = dto.Permissoes.Where(p => p.Selecionado);

            Repository.Add(grupoPermissao);
            UnitOfWork.Commit();

            foreach (var permissaoDto in permissoes)
            {
                permissaoDto.IdGrupoDePermissao = grupoPermissao.IdGrupoDePermissao;
                var permissao = Mapper.Map<Models.Entities.Permissao>(permissaoDto);
                PermissaoRepository.Add(permissao);
                UnitOfWork.Commit();
            }

            UnitOfWork.CommitTransaction();

            return new CommandResult(StatusCodes.Status201Created, Mapper.Map<GrupoDePermissaoDto>(grupoPermissao));
        }
        catch (Exception ex)
        {
            UnitOfWork.Rollback();
            return new CommandResult(ex, dto);
        }
    }
}
