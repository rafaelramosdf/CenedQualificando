using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class PermissaoQuery : IPermissaoQuery
    {
        public Expression<Func<Permissao, bool>> FiltroGenerico(string textoFiltro)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<Permissao, object>> Ordenacao(string campo)
        {
            throw new NotImplementedException();
        }
    }
}
