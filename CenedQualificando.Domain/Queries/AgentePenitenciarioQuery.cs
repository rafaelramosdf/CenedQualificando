using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class AgentePenitenciarioQuery : IAgentePenitenciarioQuery
    {
        public Expression<Func<AgentePenitenciario, bool>> ObterPesquisa(AgentePenitenciarioFilter filtro)
        {
            Expression<Func<AgentePenitenciario, bool>> query = _ => true;

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Search))
                {
                    query = x => x.Nome.Contains(filtro.Search) ||
                            x.CpfUsuario == filtro.Search;
                }
            }

            return query;
        }

        public Expression<Func<AgentePenitenciario, object>> ObterOrdenacao(string campo)
        {
            return x => x.Nome;
        }
    }
}
