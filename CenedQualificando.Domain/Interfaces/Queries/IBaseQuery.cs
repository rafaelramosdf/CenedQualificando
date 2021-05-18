using CenedQualificando.Domain.Models.Base;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Interfaces.Queries
{
    public interface IBaseQuery<TEntity>
        where TEntity : Entity
    {
        Expression<Func<TEntity, bool>> ObterFiltroGenerico(string textoFiltro);
        Expression<Func<TEntity, object>> ObterOrdenacao(string campo);
    }
}
