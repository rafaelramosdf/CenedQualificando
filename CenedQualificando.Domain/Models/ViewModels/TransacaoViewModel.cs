using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using System;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class TransacaoViewModel : ViewModel<Transacao>
    {
        public override int Id => IdTransacao;

        public int IdTransacao { get; set; }
        public int IdAluno { get; set; }
        public string NomeAluno { get; set; }
        public string NomeResponsavel { get; set; }
        public string CpfAluno { get; set; }
        public string CpfResponsavel { get; set; }
        public int IdPenitenciaria { get; set; }
        public string NomePenitenciaria { get; set; }
        public int Uf { get; set; }
        public int IdCurso { get; set; }
        public string NomeCurso { get; set; }
        public string CodigoCurso { get; set; }
        public int FormaEnvioMaterial { get; set; }
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
