using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class AgentePenitenciarioQuery : IAgentePenitenciarioQuery
    {
        public Expression<Func<AgentePenitenciario, bool>> FiltroGenerico(string textoFiltro)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<AgentePenitenciario, object>> Ordenacao(string campo)
        {
            throw new NotImplementedException();
        }
    }
}
