using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Infra.Context;
using CenedQualificando.Infra.Repository.Base;

namespace CenedQualificando.Infra.Repository
{
    public class PenitenciariaRepository : BaseRepository<Penitenciaria>, IPenitenciariaRepository
    {
        public PenitenciariaRepository(EntityContext context)
            : base(context)
        {
        }
    }
}
