using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class UfEntregaQuery : IUfEntregaQuery
    {
        public Expression<Func<UfEntrega, bool>> ObterPesquisa(UfEntregaFilter filtro)
        {
            return _ => true;
        }

        public Expression<Func<UfEntrega, object>> ObterOrdenacao(string campo)
        {
            return o => o.Uf;
        }
    }
}
