using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations.Filters;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Base;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries.Contracts
{
    public interface IMatriculaQuery : IBaseQuery<Matricula, MatriculaFilter>
    {
        Expression<Func<Matricula, bool>> FiltrarPelaSituacaoDaMatricula(MatriculaFilterEnum tipoFiltro);
    }
}
