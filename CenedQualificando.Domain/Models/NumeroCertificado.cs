using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class NumeroCertificado : Entity
    {
        public override int Id => IdNumeroCertificado;

        public int IdNumeroCertificado { get; set; }
        public string Prefixo { get; set; }
        public int Numero { get; set; }
        public string Criptografia { get; set; }
        public int IdMatricula { get; set; }
    }
}
