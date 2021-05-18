using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class EstoqueMaterial : Entity
    {
        public override int Id => IdEstoqueMaterial;

        public int IdEstoqueMaterial { get; set; }
        public int UfEstoque { get; set; }
        public int QuantidadeApostila { get; set; }
        public int QuantidadeProva { get; set; }
        public int EstoqueMinimo { get; set; }
        public int IdCurso { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
    }
}
