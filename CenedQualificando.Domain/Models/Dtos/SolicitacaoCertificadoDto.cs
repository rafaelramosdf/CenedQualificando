using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using System;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class SolicitacaoCertificadoDto : Dto<SolicitacaoCertificado>
    {
        public override int Id => IdSolicitacaoCertificado;

        public int IdSolicitacaoCertificado { get; set; }
        public int IdMatricula { get; set; }
        public string NomeSolicitante { get; set; }
        public string CpfSolicitante { get; set; }
        public string EnderecoLogradouro { get; set; }
        public string EnderecoNumero { get; set; }
        public string EnderecoComplemento { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoCidade { get; set; }
        public int EnderecoUf { get; set; }
        public string EnderecoCep { get; set; }
        public decimal ValorFrete { get; set; }
        public int Situacao { get; set; }
        public DateTime Data { get; set; }
        public string NumeroBoleto { get; set; }
        public Guid CodigoPagamento { get; set; }
        public string Telefone { get; set; }
        public int PrazoEntrega { get; set; }

        public override void Validate()
        {
        }
    }
}
