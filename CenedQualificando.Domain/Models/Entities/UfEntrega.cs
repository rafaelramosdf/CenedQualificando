using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Entities
{
    public partial class UfEntrega : Entity
    {
        public override int Id => IdUf;

        public int IdUf { get; set; }
        public int Uf { get; set; }
        public decimal Taxa { get; set; }
    }
}
