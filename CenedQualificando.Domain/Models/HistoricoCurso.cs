using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class HistoricoCurso : Entity
    {
        public override int Id => IdHistoricoCurso;

        public int IdHistoricoCurso { get; set; }
        public int IdMatricula { get; set; }
        public int IdTabelaHistoricoCurso { get; set; }
        public DateTime DataHora { get; set; }
        public string Valor { get; set; }

        public virtual Matricula IdMatriculaNavigation { get; set; }
        public virtual TabelaHistoricoCurso IdTabelaHistoricoCursoNavigation { get; set; }
    }
}
