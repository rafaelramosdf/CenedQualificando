using CenedQualificando.CrossCutting.Dtos.Base;
using CenedQualificando.Domain.Models.Entities;
using System;

namespace CenedQualificando.CrossCutting.Dtos
{
    public partial class DespesaExtraDto : Dto<DespesaExtra>
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
    }
}
