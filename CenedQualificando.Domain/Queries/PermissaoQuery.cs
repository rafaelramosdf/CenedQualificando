using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class PermissaoQuery : IPermissaoQuery
    {
        public Expression<Func<Permissao, bool>> ObterPesquisa(PermissaoFilter filtro)
        {
            if (string.IsNullOrEmpty(filtro?.Search))
                return _ => true;

            return x => x.Nome.Contains(filtro.Search);
        }

        public Expression<Func<Permissao, object>> ObterOrdenacao(string campo)
        {
            switch (campo)
            {
                case nameof(Permissao.IdPermissao):
                    return x => x.IdPermissao;
                default:
                    return x => x.Nome;
            }
        }
    }
}
