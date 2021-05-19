using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Entities
{
    public partial class GruposProvaUfCurso
    {
        public int GruposProvaUfIdGruposProvaUf { get; set; }
        public int CursoIdCurso { get; set; }

        public virtual Curso CursoIdCursoNavigation { get; set; }
        public virtual GruposProvaUf GruposProvaUfIdGruposProvaUfNavigation { get; set; }
    }
}
