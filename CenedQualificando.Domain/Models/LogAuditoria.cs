using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class LogAuditoria : Entity
    {
        public override int Id => IdLogAuditoria;

        public int IdLogAuditoria { get; set; }
        public int TipoOperacao { get; set; }
        public DateTime DataOperacao { get; set; }
        public string EnderecoIp { get; set; }
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public int CpfUsuario { get; set; }
        public string NumeroMatricula { get; set; }
        public int? IdMatricula { get; set; }
        public int SituacaoCursoAnterior { get; set; }
        public int SituacaoFinanceiraAnterior { get; set; }
        public int SituacaoCurso { get; set; }
        public int SituacaoFinanceira { get; set; }
    }
}
