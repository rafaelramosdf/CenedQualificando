using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CenedQualificando.Domain.Extensions;

namespace CenedQualificando.Domain.Models.Entities
{
    public partial class Matricula : Entity
    {
        public Matricula()
        {
            DespesaExtra = new HashSet<DespesaExtra>();
            HistoricoCurso = new HashSet<HistoricoCurso>();
            Prova = new HashSet<Prova>();
            SolicitacaoCertificado = new HashSet<SolicitacaoCertificado>();
        }

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
        public int StatusFinanceiro { get; set; }
        public string Boleto { get; set; }
        public int FormaPagamento { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int SolicitacaoCancelamento { get; set; }
        public int MaterialDidatico { get; set; }
        public DateTime? DataPostagem { get; set; }
        public int MaterialEnviadoPara { get; set; }
        public int StatusCurso { get; set; }
        public DateTime? DataStatusCurso { get; set; }
        public DateTime? CertificadoExpedido { get; set; }
        public DateTime? CertificadoEnviado { get; set; }
        public string Registro { get; set; }
        public string Pagina { get; set; }
        public string Livro { get; set; }
        public int CertificadoEnviadoPara { get; set; }
        public int EnvioMaterial { get; set; }
        public bool PossuiBolsaParceria { get; set; }
        public int StatusRotina { get; set; }

        [NotMapped]
        public string MatriculaStatusDescricao => ((StatusCursoEnum)StatusCurso).GetDescription();
        [NotMapped]
        public string CursoCodigo { get; set; }
        [NotMapped]
        public string CursoNome { get; set; }
        [NotMapped]
        public int CursoCargaHoraria { get; set; }
        [NotMapped]
        public string AlunoNome { get; set; }
        [NotMapped]
        public string AlunoCpf { get; set; }
        [NotMapped]
        public string PenitenciariaNome { get; set; }
        [NotMapped]
        public int PenitenciariaUf { get; set; }
        [NotMapped]
        public string PenitenciariaUfDescricao => PenitenciariaUf > 0 ? ((UfEnum)PenitenciariaUf).GetDescription() : "";

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Penitenciaria IdPenitenciariaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<DespesaExtra> DespesaExtra { get; set; }
        public virtual ICollection<HistoricoCurso> HistoricoCurso { get; set; }
        public virtual ICollection<Prova> Prova { get; set; }
        public virtual ICollection<SolicitacaoCertificado> SolicitacaoCertificado { get; set; }
    }
}
