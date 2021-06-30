using CenedQualificando.CrossCutting.Dtos.Base;
using CenedQualificando.Domain.Models.Entities;
using System;

namespace CenedQualificando.CrossCutting.Dtos
{
    public partial class TransacaoCieloSolicitacaoCertificadoDto : Dto<TransacaoCieloSolicitacaoCertificado>
    {
        public override int Id => IdTransacaoCieloSolicitacaoCertificado;

        public int IdTransacaoCieloSolicitacaoCertificado { get; set; }
        public string NomeSolicitante { get; set; }
        public string CpfSolicitante { get; set; }
        public string NumeroBoleto { get; set; }
        public Guid CodigoPagamento { get; set; }
        public int FormaPagamento { get; set; }
        public int BandeiraCartao { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public int UltimaSituacao { get; set; }
        public DateTime DataUltimaSituacao { get; set; }
        public string NumeroPedido { get; set; }
        public string IdTransacaoCielo { get; set; }
        public string UrlPagamentoCielo { get; set; }
        public string MensagemErro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UfEntrega { get; set; }
        public string Cep { get; set; }
    }
}
