using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Entities
{
    public partial class Matricula : Entity
    {
        public Matricula()
        {
            DespesasExtras = new HashSet<DespesaExtra>();
            HistoricoCurso = new HashSet<HistoricoCurso>();
            Provas = new HashSet<Prova>();
            SolicitacoesCertificados = new HashSet<SolicitacaoCertificado>();
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

        public virtual Aluno Aluno { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual Penitenciaria Penitenciaria { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<DespesaExtra> DespesasExtras { get; set; }
        public virtual ICollection<HistoricoCurso> HistoricoCurso { get; set; }
        public virtual ICollection<Prova> Provas { get; set; }
        public virtual ICollection<SolicitacaoCertificado> SolicitacoesCertificados { get; set; }
    }
}
