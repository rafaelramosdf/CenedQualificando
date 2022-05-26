using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class CargaHorariaDiariaQuery : ICargaHorariaDiariaQuery
    {
        public Expression<Func<CargaHorariaDiaria, bool>> Filtrar(CargaHorariaDiariaFilter filtro)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<CargaHorariaDiaria, object>> Ordenar(string campo)
        {
            throw new NotImplementedException();
        }
    }
}
