using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Models;
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
