using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class FiscalSalaQuery : IFiscalSalaQuery
    {
        public Expression<Func<FiscalSala, bool>> FiltroGenerico(string textoFiltro)
        {
            return x => x.Nome.Contains(textoFiltro) || x.Cpf.Contains(textoFiltro);
        }

        public Expression<Func<FiscalSala, object>> Ordenacao(string campo)
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
