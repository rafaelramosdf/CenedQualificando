using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class PenitenciariaQuery : IPenitenciariaQuery
    {
        public Expression<Func<Penitenciaria, bool>> FiltroGenerico(string textoFiltro)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<Penitenciaria, object>> Ordenacao(string campo)
        {
            throw new NotImplementedException();
        }
    }
}
