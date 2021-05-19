using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Entities
{
    public partial class MensagemPersonalizada : Entity
    {
        public override int Id => IdMensagemPersonalizada;

        public int IdMensagemPersonalizada { get; set; }
        public string Codigo { get; set; }
        public string Mensagem { get; set; }
    }
}
