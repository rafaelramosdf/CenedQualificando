using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class CargaHorariaDiariaQuery : ICargaHorariaDiariaQuery
    {
        public Expression<Func<CargaHorariaDiaria, bool>> FiltroGenerico(string textoFiltro)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<CargaHorariaDiaria, object>> Ordenacao(string campo)
        {
            throw new NotImplementedException();
        }
    }
}
