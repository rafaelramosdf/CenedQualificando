﻿using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using System;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class AgentePenitenciarioParceriaPagamentosViewModel : ViewModel<AgentePenitenciarioParceriaPagamentos>
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
