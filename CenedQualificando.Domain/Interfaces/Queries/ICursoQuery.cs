using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Domain.Interfaces.Queries
{
    public interface ICursoQuery : IBaseQuery<Curso, CursoFilter>
    {
    }
}
