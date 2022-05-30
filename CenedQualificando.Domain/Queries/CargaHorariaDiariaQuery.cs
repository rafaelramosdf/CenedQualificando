using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class CargaHorariaDiariaQuery : ICargaHorariaDiariaQuery
    {
        public Expression<Func<CargaHorariaDiaria, bool>> Filtrar(CargaHorariaDiariaFilter filtro)
        {
            return _ => true;
        }

        public Expression<Func<CargaHorariaDiaria, object>> Ordenar(string campo)
        {
            return o => o.Uf;
        }
    }
}
