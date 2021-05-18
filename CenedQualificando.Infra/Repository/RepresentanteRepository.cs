using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Models;
using CenedQualificando.Infra.Context;
using CenedQualificando.Infra.Repository.Base;

namespace CenedQualificando.Infra.Repository
{
    public class RepresentanteRepository : BaseRepository<Representante>, IRepresentanteRepository
    {
        public RepresentanteRepository(EntityContext context)
            : base(context)
        {
        }
    }
}
