using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class GrupoProva : Entity
    {
        public GrupoProva()
        {
            GruposProvaUf = new HashSet<GruposProvaUf>();
        }

        public override int Id => IdGrupoProva;

        public int IdGrupoProva { get; set; }
        public string Nome { get; set; }
        public int Ativo { get; set; }
        public string Prova1 { get; set; }
        public string Prova2 { get; set; }
        public string Prova3 { get; set; }
        public string Prova4 { get; set; }
        public string Prova5 { get; set; }

        public virtual ICollection<GruposProvaUf> GruposProvaUf { get; set; }
    }
}
