using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class ProvaQuery : IProvaQuery
    {
        public Expression<Func<Prova, bool>> Filtrar(ProvaFilter filtro)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<Prova, object>> Ordenar(string campo)
        {
            throw new NotImplementedException();
        }
    }
}
