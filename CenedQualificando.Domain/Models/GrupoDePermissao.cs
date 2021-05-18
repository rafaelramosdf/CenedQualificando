using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class GrupoDePermissao : Entity
    {
        public GrupoDePermissao()
        {
            AgentePenitenciario = new HashSet<AgentePenitenciario>();
            Permissao = new HashSet<Permissao>();
            Usuario = new HashSet<Usuario>();
        }

        public override int Id => IdGrupoDePermissao;

        public int IdGrupoDePermissao { get; set; }
        public string Descricao { get; set; }
        public bool Oculto { get; set; }

        public virtual ICollection<AgentePenitenciario> AgentePenitenciario { get; set; }
        public virtual ICollection<Permissao> Permissao { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
