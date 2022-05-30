using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class GrupoDePermissaoQuery : IGrupoDePermissaoQuery
    {
        public Expression<Func<GrupoDePermissao, bool>> Filtrar(GrupoDePermissaoFilter filtro)
        {
            if (string.IsNullOrEmpty(filtro?.Search))
                return _ => true;

            return x => x.Descricao.Contains(filtro.Search);
        }

        public Expression<Func<GrupoDePermissao, object>> Ordenar(string campo)
        {
            switch (campo)
            {
                case nameof(GrupoDePermissao.IdGrupoDePermissao):
                    return x => x.IdGrupoDePermissao;
                default:
                    return x => x.Descricao;
            }
        }
    }
}
