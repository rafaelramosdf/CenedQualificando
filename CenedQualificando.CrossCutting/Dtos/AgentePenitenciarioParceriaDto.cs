using System;
using CenedQualificando.CrossCutting.Dtos.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.CrossCutting.Dtos
{
    public partial class AgentePenitenciarioParceriaDto : Dto<AgentePenitenciarioParceria>
    {
        public override int Id => IdAgentePenitenciarioParceria;

        public int IdAgentePenitenciarioParceria { get; set; }
        public int IdAgentePenitenciario { get; set; }
        public int IdPenitenciaria { get; set; }
        public DateTime? DataInicioParceria { get; set; }
    }
}
