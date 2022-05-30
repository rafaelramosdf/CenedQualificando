using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Repositories.Contracts;
using CenedQualificando.Infra.Context;
using CenedQualificando.Infra.Repository.Base;

namespace CenedQualificando.Infra.Repository
{
    public class UfEntregaRepository : BaseRepository<UfEntrega>, IUfEntregaRepository
    {
        public UfEntregaRepository(EntityContext context)
            : base(context)
        {
        }
    }
}
