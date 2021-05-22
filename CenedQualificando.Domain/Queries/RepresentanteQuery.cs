using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class RepresentanteQuery : IRepresentanteQuery
    {
        public Expression<Func<Representante, bool>> FiltroGenerico(string textoFiltro)
        {
            return x => x.Nome.Contains(textoFiltro);
        }

        public Expression<Func<Representante, object>> Ordenacao(string campo)
        {
            switch (campo)
            {
                default:
                    return x => x.Nome;
            }
        }
    }
}
