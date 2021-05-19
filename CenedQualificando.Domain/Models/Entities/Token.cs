using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Entities
{
    public partial class Token : Entity
    {
        public override int Id => IdToken;

        public int IdToken { get; set; }
        public string Cpf { get; set; }
        public string IdCurso { get; set; }
        public string NomeCurso { get; set; }
        public decimal ValorTotal { get; set; }
        public string Referencia { get; set; }
    }
}
