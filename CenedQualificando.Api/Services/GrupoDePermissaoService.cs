using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Models.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Api.Services
{
    public class GrupoDePermissaoService : BaseService<GrupoDePermissao, 
        GrupoDePermissaoDto,
        GrupoDePermissaoFilter,
        IGrupoDePermissaoQuery, 
        IGrupoDePermissaoRepository>, 
        IGrupoDePermissaoService
    {
        private readonly IPermissaoService _permissaoService;

        public GrupoDePermissaoService(
            IGrupoDePermissaoQuery query,
            IGrupoDePermissaoRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPermissaoService permissaoService,
            ILogger<GrupoDePermissaoService> log) :
            base(query, repository, unitOfWork, mapper, log)
        {
            _permissaoService = permissaoService;
        }

        public IEnumerable<int> GetIdPermissoes(int idGrupoPermissao)
        {
            return Repository.GetIdPermissoes(idGrupoPermissao);
        }

        public override CommandResult Incluir(GrupoDePermissaoDto vm)
        {
            var commandResult = new CommandResult();

            try
            {
                UnitOfWork.BeginTransaction();

                var grupoPermissao = Mapper.Map<GrupoDePermissao>(vm);
                var permissoes = vm.Permissoes.Where(p => p.Selecionado);

                Repository.Add(grupoPermissao);
                UnitOfWork.Commit();

                foreach (var item in permissoes)
                {
                    item.IdGrupoDePermissao = grupoPermissao.IdGrupoDePermissao;
                    var permissao = Mapper.Map<PermissaoDto>(item);
                    var commandResultPermissoes = _permissaoService.Incluir(permissao);

                    if (commandResultPermissoes.HasError)
                    {
                        commandResult.SetErrors(commandResultPermissoes.Errors.ToList());
                        return commandResult;
                    }
                }

                UnitOfWork.CommitTransaction();

                return new CommandResult(StatusCodes.Status200OK, Mapper.Map<GrupoDePermissaoDto>(grupoPermissao));
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                commandResult.Data = vm;
                commandResult.StatusCode = StatusCodes.Status500InternalServerError;
                commandResult.SetError(ex.Message);
                return commandResult;
            }
        }

        public override CommandResult Alterar(GrupoDePermissaoDto vm)
        {
            var commandResult = new CommandResult();

            try
            {
                UnitOfWork.BeginTransaction();

                var grupoPermissao = Mapper.Map<GrupoDePermissao>(vm);
                var permissoes = vm.Permissoes.Where(p => p.Selecionado);

                var idPermissoesAntigas = GetIdPermissoes(grupoPermissao.IdGrupoDePermissao);
                foreach (var id in idPermissoesAntigas)
                {
                    var commandResultExclusaoPermissoes = _permissaoService.Excluir(id);
                    if (commandResultExclusaoPermissoes.HasError)
                    {
                        commandResult.SetErrors(commandResultExclusaoPermissoes.Errors.ToList());
                        return commandResult;
                    }
                }

                Repository.Update(grupoPermissao);
                UnitOfWork.Commit();

                foreach (var item in permissoes)
                {
                    item.IdGrupoDePermissao = grupoPermissao.IdGrupoDePermissao;
                    var permissao = Mapper.Map<PermissaoDto>(item);
                    var commandResultInclusaoPermissoes = _permissaoService.Incluir(permissao);

                    if (commandResultInclusaoPermissoes.HasError)
                    {
                        commandResult.SetErrors(commandResultInclusaoPermissoes.Errors.ToList());
                        return commandResult;
                    }
                }

                UnitOfWork.CommitTransaction();

                return new CommandResult(StatusCodes.Status204NoContent, null);
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                commandResult.StatusCode = StatusCodes.Status500InternalServerError;
                commandResult.SetError(ex.Message);
                return commandResult;
            }
        }
    }
}
