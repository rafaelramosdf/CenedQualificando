using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class TabelaHistoricoCurso : Entity
    {
        public TabelaHistoricoCurso()
        {
            HistoricoCurso = new HashSet<HistoricoCurso>();
        }

        public override int Id => IdTabelaHistoricoCurso;

        public int IdTabelaHistoricoCurso { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Agrupador { get; set; }
        public int Tipo { get; set; }
        public bool PreDefinido { get; set; }
        public int Ativo { get; set; }

        public virtual ICollection<HistoricoCurso> HistoricoCurso { get; set; }
    }
}
