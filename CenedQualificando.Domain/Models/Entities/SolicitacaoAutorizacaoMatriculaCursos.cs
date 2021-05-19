using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Entities
{
    public partial class SolicitacaoAutorizacaoMatriculaCursos : Entity
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
