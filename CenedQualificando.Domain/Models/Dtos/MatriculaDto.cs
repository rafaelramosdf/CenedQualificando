using System;
using System.Collections.Generic;
using System.Linq;
using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;

namespace CenedQualificando.Domain.Models.Dtos
{
    public class MatriculaDto : Dto<Matricula>
    {
        public override int Id => IdMatricula;

        public int IdMatricula { get; set; }
        public int IdAluno { get; set; }
        public int IdPenitenciaria { get; set; }
        public string NumeroMatricula { get; set; }
        public int IdCurso { get; set; }
        public string Representante { get; set; }
        public DateTime? DataMatricula { get; set; }
        public DateTime? InicioCurso { get; set; }
        public DateTime? TerminoCurso { get; set; }
        public int Periodo { get; set; }
        public DateTime? DataPiso { get; set; }
        public DateTime? DataPrescricao { get; set; }
        public string Observacoes { get; set; }
        public int IdUsuario { get; set; }
        public StatusFinanceiroEnum StatusFinanceiro { get; set; }
        public string StatusFinanceiroDescricao => StatusFinanceiro.GetDescription();
        public string Boleto { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public string FormaPagamentoDescricao => FormaPagamento.GetDescription();
        public decimal ValorTotal { get; set; }
        public DateTime? DataPagamento { get; set; }
        public SolicitacaoCancelamentoPorEnum SolicitacaoCancelamento { get; set; }
        public string SolicitacaoCancelamentoDescricao => SolicitacaoCancelamento.GetDescription();
        public MaterialDidaticoEnum MaterialDidatico { get; set; }
        public string MaterialDidaticoDescricao => MaterialDidatico.GetDescription();
        public DateTime? DataPostagem { get; set; }
        public EnvioMaterialEnum MaterialEnviadoPara { get; set; }
        public string MaterialEnviadoParaDescricao => MaterialEnviadoPara.GetDescription();
        public StatusCursoEnum StatusCurso { get; set; }
        public string StatusCursoDescricao => StatusCurso.GetDescription();
        public DateTime? DataStatusCurso { get; set; }
        public DateTime? CertificadoExpedido { get; set; }
        public DateTime? CertificadoEnviado { get; set; }
        public string Registro { get; set; }
        public string Pagina { get; set; }
        public string Livro { get; set; }
        public EnviadoParaEnum CertificadoEnviadoPara { get; set; }
        public string CertificadoEnviadoParaDescricao => CertificadoEnviadoPara.GetDescription();
        public EnvioMaterialEnum EnvioMaterial { get; set; }
        public string EnvioMaterialDescricao => EnvioMaterial.GetDescription();
        public bool PossuiBolsaParceria { get; set; }

        public string MatriculaStatusDescricao => ((StatusCursoEnum)StatusCurso).GetDescription();
        public string CursoCodigo { get; set; }
        public string CursoNome { get; set; }
        public int CursoCargaHoraria { get; set; }
        public string AlunoNome { get; set; }
        public string AlunoCpf { get; set; }
        public string PenitenciariaNome { get; set; }
        public UfEnum PenitenciariaUf { get; set; }
        public string PenitenciariaUfDescricao => PenitenciariaUf != UfEnum.Null ? PenitenciariaUf.GetDescription() : "";

        public AlunoDto Aluno { get; set; } = new AlunoDto();

        // DADOS DE PROVAS
        public IEnumerable<ProvaDto> Provas { get; set; } = new List<ProvaDto>();
        public DateTime? DataRecebimentoUltimaProva => Provas.LastOrDefault()?.DataRecebidaProva;
        public decimal? NotaProva => Provas.LastOrDefault()?.Nota;

        public override void Validate()
        {
        }
    }
}
