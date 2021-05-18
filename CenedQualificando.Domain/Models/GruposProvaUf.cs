using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class GruposProvaUf : Entity
    {
        public GruposProvaUf()
        {
            GruposProvaUfCurso = new HashSet<GruposProvaUfCurso>();
        }

        public override int Id => IdGruposProvaUf;

        public int IdGruposProvaUf { get; set; }
        public int IdGrupoProva { get; set; }
        public int Uf { get; set; }

        public virtual GrupoProva IdGrupoProvaNavigation { get; set; }
        public virtual ICollection<GruposProvaUfCurso> GruposProvaUfCurso { get; set; }
    }
}
