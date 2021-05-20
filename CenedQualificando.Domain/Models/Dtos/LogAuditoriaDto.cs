using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using System;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class LogAuditoriaDto : Dto<LogAuditoria>
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

        public override void Validate()
        {
        }
    }
}
