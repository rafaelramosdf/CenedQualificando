using System;
using System.Collections.Generic;
using System.Linq;
using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public class MatriculaViewModel : ViewModel<Matricula>
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
        public string StatusFinanceiroDescricao => StatusFinanceiro.EnumDescription();
        public string Boleto { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public string FormaPagamentoDescricao => FormaPagamento.EnumDescription();
        public decimal ValorTotal { get; set; }
        public DateTime? DataPagamento { get; set; }
        public SolicitacaoCancelamentoPorEnum SolicitacaoCancelamento { get; set; }
        public string SolicitacaoCancelamentoDescricao => SolicitacaoCancelamento.EnumDescription();
        public MaterialDidaticoEnum MaterialDidatico { get; set; }
        public string MaterialDidaticoDescricao => MaterialDidatico.EnumDescription();
        public DateTime? DataPostagem { get; set; }
        public EnviadoParaEnum MaterialEnviadoPara { get; set; }
        public string MaterialEnviadoParaDescricao => MaterialEnviadoPara.EnumDescription();
        public StatusCursoEnum StatusCurso { get; set; }
        public string StatusCursoDescricao => StatusCurso.EnumDescription();
        public DateTime? DataStatusCurso { get; set; }
        public DateTime? CertificadoExpedido { get; set; }
        public DateTime? CertificadoEnviado { get; set; }
        public string Registro { get; set; }
        public string Pagina { get; set; }
        public string Livro { get; set; }
        public EnviadoParaEnum CertificadoEnviadoPara { get; set; }
        public string CertificadoEnviadoParaDescricao => CertificadoEnviadoPara.EnumDescription();
        public EnvioMaterialEnum EnvioMaterial { get; set; }
        public string EnvioMaterialDescricao => EnvioMaterial.EnumDescription();
        public bool PossuiBolsaParceria { get; set; }

        public ProvaViewModel UltimaProvaRealizada => Provas != null && Provas.Any() 
            ? Provas.OrderByDescending(o => o.DataRecebidaProva).FirstOrDefault(x => x.DataRecebidaProva.HasValue) 
            : null;

        public AlunoViewModel Aluno { get; set; } = new AlunoViewModel();
        public CursoViewModel Curso { get; set; } = new CursoViewModel();
        public PenitenciariaViewModel Penitenciaria { get; set; } = new PenitenciariaViewModel();
        public IEnumerable<ProvaViewModel> Provas { get; set; } = new List<ProvaViewModel>();
    }
}
