using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Api.Services.Contracts;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Api.Services
{
    public class GrupoDePermissaoService : BaseService<GrupoDePermissao, GrupoDePermissaoDto, IGrupoDePermissaoQuery, IGrupoDePermissaoRepository>, IGrupoDePermissaoService
    {
        private readonly IPermissaoService _permissaoService;

        public GrupoDePermissaoService(
            IGrupoDePermissaoQuery query,
            IGrupoDePermissaoRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPermissaoService permissaoService) :
            base(query, repository, unitOfWork, mapper)
        {
            _permissaoService = permissaoService;
        }

        public async Task<IEnumerable<PermissaoDto>> GetPermissoesAsync(int idGrupoPermissao)
        {
            return Mapper.Map<IEnumerable<PermissaoDto>>(await Repository.GetPermissoesAsync(idGrupoPermissao));
        }

        public override GrupoDePermissaoDto Incluir(GrupoDePermissaoDto vm)
        {
            UnitOfWork.BeginTransaction();

            var grupoPermissao = Mapper.Map<GrupoDePermissao>(vm);
            var permissoes = vm.Permissoes.Where(p => p.Selecionado);

            try
            {
                Repository.Add(grupoPermissao);
                UnitOfWork.Commit();

                foreach (var item in permissoes)
                {
                    item.IdGrupoDePermissao = grupoPermissao.IdGrupoDePermissao;
                    var permissao = Mapper.Map<PermissaoDto>(item);
                    _permissaoService.Incluir(permissao);
                }

                UnitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                UnitOfWork.Rollback();
                throw e;
            }

            return Mapper.Map<GrupoDePermissaoDto>(grupoPermissao);
        }

        public override void Alterar(GrupoDePermissaoDto vm)
        {
            UnitOfWork.BeginTransaction();

            var grupoPermissao = Mapper.Map<GrupoDePermissao>(vm);
            var permissoes = vm.Permissoes.Where(p => p.Selecionado);

            try
            {
                var permissoesAntigas = GetPermissoesAsync(grupoPermissao.IdGrupoDePermissao).Result;
                foreach (var permissao in permissoesAntigas)
                {
                    _permissaoService.Excluir(permissao);
                }

                Repository.Update(grupoPermissao);
                UnitOfWork.Commit();

                foreach (var item in permissoes)
                {
                    item.IdGrupoDePermissao = grupoPermissao.IdGrupoDePermissao;
                    var permissao = Mapper.Map<PermissaoDto>(item);
                    _permissaoService.Incluir(permissao);
                }

                UnitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                UnitOfWork.Rollback();
                throw e;
            }
        }
    }
}
