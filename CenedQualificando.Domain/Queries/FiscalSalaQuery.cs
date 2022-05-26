using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class FiscalSalaQuery : IFiscalSalaQuery
    {
        public Expression<Func<FiscalSala, bool>> Filtrar(FiscalSalaFilter filtro)
        {
            return x => x.Nome.Contains(filtro.Search) || x.Cpf.Contains(filtro.Search);
        }

        public Expression<Func<FiscalSala, object>> Ordenar(string campo)
        {
            switch (campo)
            {
                case nameof(Aluno.Nome):
                    return x => x.Nome;
                default:
                    return x => x.Nome;
            }
        }
    }
}
