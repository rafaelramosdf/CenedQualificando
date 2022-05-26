using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class GrupoDePermissaoQuery : IGrupoDePermissaoQuery
    {
        public Expression<Func<GrupoDePermissao, bool>> Filtrar(GrupoDePermissaoFilter filtro)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<GrupoDePermissao, object>> Ordenar(string campo)
        {
            throw new NotImplementedException();
        }
    }
}
