using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Base;
using System.Linq;

namespace CenedQualificando.Domain.Queries.Contracts
{
    public interface IMatriculaQuery : IBaseQuery<Matricula, MatriculaFilter>
    {
        IQueryable<Matricula> FiltrarMatriculas(MatriculaFilter filtro, IQueryable<Matricula> queryList);
    }
}
