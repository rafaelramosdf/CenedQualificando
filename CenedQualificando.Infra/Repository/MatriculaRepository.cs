using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Models;
using CenedQualificando.Infra.Context;
using CenedQualificando.Infra.Repository.Base;

namespace CenedQualificando.Infra.Repository
{
    public class MatriculaRepository : BaseRepository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(EntityContext context)
            : base(context)
        {
        }
    }
}
