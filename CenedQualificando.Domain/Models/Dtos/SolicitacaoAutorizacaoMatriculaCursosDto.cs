using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using System;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class SolicitacaoAutorizacaoMatriculaCursosDto : Dto<SolicitacaoAutorizacaoMatriculaCursos>
    {
        public override int Id => IdSolicitacaoAutorizacaoMatriculaCursos;

        public int IdSolicitacaoAutorizacaoMatriculaCursos { get; set; }
        public int? IdAgentePenitenciario { get; set; }
        public int Situacao { get; set; }
        public DateTime? DataUltimaSituacao { get; set; }
        public int IdSolicitacaoAutorizacaoMatricula { get; set; }
        public int IdCurso { get; set; }
    }
}
