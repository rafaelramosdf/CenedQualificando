using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class CursoQuery : ICursoQuery
    {
        public Expression<Func<Curso, bool>> FiltroGenerico(string textoFiltro)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<Curso, object>> Ordenacao(string campo)
        {
            throw new NotImplementedException();
        }
    }
}
