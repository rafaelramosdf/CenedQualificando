using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Entities
{
    public partial class TransacaoCieloSolicitacaoCertificado : Entity
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
