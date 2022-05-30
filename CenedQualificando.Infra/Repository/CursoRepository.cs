using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Repositories.Contracts;
using CenedQualificando.Infra.Context;
using CenedQualificando.Infra.Repository.Base;

namespace CenedQualificando.Infra.Repository
{
    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        public CursoRepository(EntityContext context)
            : base(context)
        {
        }
    }
}
