using System;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class AgentePenitenciarioParceriaDto : Dto<AgentePenitenciarioParceria>
    {
        public override int Id => IdAgentePenitenciarioParceria;

        public int IdAgentePenitenciarioParceria { get; set; }
        public int IdAgentePenitenciario { get; set; }
        public int IdPenitenciaria { get; set; }
        public DateTime? DataInicioParceria { get; set; }

        public override void Validate()
        {
        }
    }
}
