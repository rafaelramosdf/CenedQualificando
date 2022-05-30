using System.Collections.Generic;
using System.Linq;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Repositories.Contracts;
using CenedQualificando.Infra.Context;
using CenedQualificando.Infra.Repository.Base;

namespace CenedQualificando.Infra.Repository
{
    public class GrupoDePermissaoRepository : BaseRepository<GrupoDePermissao>, IGrupoDePermissaoRepository
    {
        protected readonly IPermissaoRepository _permissaoRepository;

        public GrupoDePermissaoRepository(EntityContext context, 
            IPermissaoRepository permissaoRepository)
            : base(context)
        {
            _permissaoRepository = permissaoRepository;
        }

        public IEnumerable<int> GetIdPermissoes(int idGrupoPermissao)
        {
            return _permissaoRepository.List(per => per.IdGrupoDePermissao == idGrupoPermissao).Select(s => s.IdPermissao).ToList();
        }
    }
}
