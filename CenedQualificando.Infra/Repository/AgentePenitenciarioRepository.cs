using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Repositories.Contracts;
using CenedQualificando.Infra.Context;
using CenedQualificando.Infra.Repository.Base;

namespace CenedQualificando.Infra.Repository
{
    public class AgentePenitenciarioRepository : BaseRepository<AgentePenitenciario>, IAgentePenitenciarioRepository
    {
        public AgentePenitenciarioRepository(EntityContext context)
            : base(context)
        {
        }
    }
}
