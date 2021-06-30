using CenedQualificando.CrossCutting.Dtos.Base;
using CenedQualificando.Domain.Models.Entities;
using System;

namespace CenedQualificando.CrossCutting.Dtos
{
    public partial class AgentePenitenciarioParceriaPagamentosViewModel : Dto<AgentePenitenciarioParceriaPagamentos>
    {
        public override int Id => IdAgentePenitenciarioParceriaPagamentos;

        public int IdAgentePenitenciarioParceriaPagamentos { get; set; }
        public DateTime? PeriodoInicio { get; set; }
        public DateTime? PeriodoFim { get; set; }
        public string Observacoes { get; set; }
        public decimal? ValorPeriodo { get; set; }
        public decimal? ValorPago { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int IdAgentePenitenciario { get; set; }
        public DateTime? RecebimentoConfirmado { get; set; }
        public string RecebimentoConfirmadoPor { get; set; }
    }
}
