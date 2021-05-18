using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class NumeroMatricula : Entity
    {
        public override int Id => IdNumeroMatricula;

        public int IdNumeroMatricula { get; set; }
        public string Prefixo { get; set; }
        public int Numero { get; set; }
    }
}
