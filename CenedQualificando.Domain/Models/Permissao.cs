using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class Permissao : Entity
    {
        public override int Id => IdPermissao;

        public int IdPermissao { get; set; }
        public string Nome { get; set; }
        public int IdGrupoDePermissao { get; set; }

        public virtual GrupoDePermissao IdGrupoDePermissaoNavigation { get; set; }
    }
}
