using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Repositories.Contracts;
using CenedQualificando.Infra.Context;
using CenedQualificando.Infra.Repository.Base;

namespace CenedQualificando.Infra.Repository
{
    public class PermissaoRepository : BaseRepository<Permissao>, IPermissaoRepository
    {
        public PermissaoRepository(EntityContext context)
            : base(context)
        {
        }

    }
}
