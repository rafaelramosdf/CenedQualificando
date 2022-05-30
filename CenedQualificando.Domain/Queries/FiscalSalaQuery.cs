using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class FiscalSalaQuery : IFiscalSalaQuery
    {
        public Expression<Func<FiscalSala, bool>> Filtrar(FiscalSalaFilter filtro)
        {
            if (string.IsNullOrEmpty(filtro?.Search))
                return _ => true;

            return x => x.Nome.Contains(filtro.Search) || x.Cpf.Contains(filtro.Search);
        }

        public Expression<Func<FiscalSala, object>> Ordenar(string campo)
        {
            switch (campo)
            {
                case nameof(FiscalSala.IdFiscalSala):
                    return x => x.IdFiscalSala;
                default:
                    return x => x.Nome;
            }
        }
    }
}
