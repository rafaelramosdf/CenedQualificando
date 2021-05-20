using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class UsuarioQuery : IUsuarioQuery
    {
        public Expression<Func<Usuario, bool>> FiltroGenerico(string textoFiltro)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<Usuario, object>> Ordenacao(string campo)
        {
            throw new NotImplementedException();
        }
    }
}
