using CenedQualificando.Domain.Models.Base;
using System;

namespace CenedQualificando.Domain.Models.Entities
{
    public partial class AgentePenitenciarioParceria : Entity
    {
        public override int Id => IdAgentePenitenciarioParceria;

        public int IdAgentePenitenciarioParceria { get; set; }
        public int IdAgentePenitenciario { get; set; }
        public int IdPenitenciaria { get; set; }
        public DateTime? DataInicioParceria { get; set; }
    }
}
