using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class CargaHorariaDiariaQuery : ICargaHorariaDiariaQuery
    {
        public Expression<Func<CargaHorariaDiaria, bool>> ObterPesquisa(CargaHorariaDiariaFilter filtro)
        {
            if (string.IsNullOrEmpty(filtro?.Search))
                return _ => true;

            return _ => true;
        }

        public Expression<Func<CargaHorariaDiaria, object>> ObterOrdenacao(string campo)
        {
            return o => o.Uf;
        }
    }
}
