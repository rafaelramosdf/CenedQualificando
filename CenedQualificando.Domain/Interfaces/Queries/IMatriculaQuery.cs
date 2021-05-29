using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations.Filters;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Interfaces.Queries
{
    public interface IMatriculaQuery : IBaseQuery<Matricula>
    {
        Expression<Func<Matricula, bool>> FiltroPersonalizado(MatriculaFilterEnum tipoFiltro);
    }
}
