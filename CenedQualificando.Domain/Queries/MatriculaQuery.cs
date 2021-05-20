using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class MatriculaQuery : IMatriculaQuery
    {
        public Expression<Func<Matricula, bool>> FiltroGenerico(string textoFiltro)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<Matricula, object>> Ordenacao(string campo)
        {
            throw new NotImplementedException();
        }
    }
}
