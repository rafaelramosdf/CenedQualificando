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
            return x => x.Codigo == textoFiltro || x.Nome.Contains(textoFiltro);
        }

        public Expression<Func<Curso, object>> Ordenacao(string campo)
        {
            switch (campo)
            {
                default:
                    return x => x.Nome;
            }
        }
    }
}
