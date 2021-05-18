using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class DespesaExtra : Entity
    {
        public override int Id => IdDespesaExtra;

        public int IdDespesaExtra { get; set; }
        public int IdMatricula { get; set; }
        public int Status { get; set; }
        public string Tipo { get; set; }
        public string Boleto { get; set; }
        public int FormaPagamento { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataPagamento { get; set; }

        public virtual Matricula IdMatriculaNavigation { get; set; }
    }
}
