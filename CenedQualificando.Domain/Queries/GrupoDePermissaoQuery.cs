using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class GrupoDePermissaoQuery : IGrupoDePermissaoQuery
    {
        public Expression<Func<GrupoDePermissao, bool>> FiltroGenerico(string textoFiltro)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<GrupoDePermissao, object>> Ordenacao(string campo)
        {
            throw new NotImplementedException();
        }
    }
}
