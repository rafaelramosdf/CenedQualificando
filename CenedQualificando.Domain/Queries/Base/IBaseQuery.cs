using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Queries.Filters.Base;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries.Base
{
    public interface IBaseQuery<TEntity, TFilter>
        where TEntity : Entity
        where TFilter : Filter
    {
        Expression<Func<TEntity, bool>> ObterPesquisa(TFilter filtro);
        Expression<Func<TEntity, object>> ObterOrdenacao(string campo);
    }
}
