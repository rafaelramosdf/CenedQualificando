using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class PermissaoQuery : IPermissaoQuery
    {
        public Expression<Func<Permissao, bool>> Filtrar(PermissaoFilter filtro)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<Permissao, object>> Ordenar(string campo)
        {
            throw new NotImplementedException();
        }
    }
}
