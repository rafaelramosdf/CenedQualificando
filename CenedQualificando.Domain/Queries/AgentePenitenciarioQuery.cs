using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class AgentePenitenciarioQuery : IAgentePenitenciarioQuery
    {
        public Expression<Func<AgentePenitenciario, bool>> Filtrar(AgentePenitenciarioFilter filtro)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<AgentePenitenciario, object>> Ordenar(string campo)
        {
            throw new NotImplementedException();
        }
    }
}
