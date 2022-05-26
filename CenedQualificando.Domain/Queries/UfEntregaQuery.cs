using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class UfEntregaQuery : IUfEntregaQuery
    {
        public Expression<Func<UfEntrega, bool>> Filtrar(UfEntregaFilter filtro)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<UfEntrega, object>> Ordenar(string campo)
        {
            throw new NotImplementedException();
        }
    }
}
