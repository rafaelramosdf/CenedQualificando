using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class CursoUf : Entity
    {
        public CursoUf()
        {
            CursoUfCurso = new HashSet<CursoUfCurso>();
        }

        public override int Id => IdCursoUf;

        public int IdCursoUf { get; set; }
        public int Uf { get; set; }

        public virtual ICollection<CursoUfCurso> CursoUfCurso { get; set; }
    }
}
