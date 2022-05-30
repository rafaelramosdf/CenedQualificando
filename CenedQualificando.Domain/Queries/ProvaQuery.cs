using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class ProvaQuery : IProvaQuery
    {
        public Expression<Func<Prova, bool>> Filtrar(ProvaFilter filtro)
        {
            if (string.IsNullOrEmpty(filtro?.Search))
                return _ => true;

            return x => x.TipoProva.Contains(filtro.Search);
        }

        public Expression<Func<Prova, object>> Ordenar(string campo)
        {
            switch (campo)
            {
                case nameof(Prova.IdProva):
                    return x => x.IdProva;
                default:
                    return x => x.DataRecebidaProva;
            }
        }
    }
}
