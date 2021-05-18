using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class FiscalSalaQuery : IFiscalSalaQuery
    {
        public Expression<Func<FiscalSala, bool>> ObterFiltroGenerico(string textoFiltro)
        {
            return x => x.Nome.Contains(textoFiltro) || x.Cpf.Contains(textoFiltro);
        }

        public Expression<Func<FiscalSala, object>> ObterOrdenacao(string campo)
        {
            switch (campo)
            {
                case nameof(Aluno.Id):
                    return x => x.IdFiscalSala;
                default:
                    return x => x.Nome;
            }
        }
    }
}
