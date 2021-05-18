using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class NumeroOficio : Entity
    {
        public override int Id => IdNumeroOficio;

        public int IdNumeroOficio { get; set; }
        public int Numero { get; set; }
        public int Ano { get; set; }
    }
}
