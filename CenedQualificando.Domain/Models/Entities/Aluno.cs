using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Entities
{
    public partial class Aluno : Entity
    {
        public Aluno()
        {
            Matricula = new HashSet<Matricula>();
            Mensagem = new HashSet<Mensagem>();
        }

        public override int Id => IdAluno;

        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public int Sexo { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string OrgaoExpedidor { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Naturalidade { get; set; }
        public int UfNaturalidade { get; set; }
        public string Nacionalidade { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int UfResidencial { get; set; }
        public string Cep { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public string Celular { get; set; }
        public string FoneResidencial { get; set; }
        public string FoneComercial { get; set; }
        public string Email { get; set; }
        public string NomePreposto { get; set; }
        public int Vinculo { get; set; }
        public int SexoPreposto { get; set; }
        public string CpfPreposto { get; set; }
        public string RgPreposto { get; set; }
        public string OrgaoExpedidorPreposto { get; set; }
        public string GrauInstrucao { get; set; }
        public string AtuacaoHabilitacao { get; set; }
        public string Profissao { get; set; }
        public string LocalTrabalho { get; set; }
        public string CidadeTrabalho { get; set; }
        public int UfTrabalho { get; set; }
        public int IdPenitenciaria { get; set; }
        public string Bloco { get; set; }
        public string Ala { get; set; }
        public string Cela { get; set; }
        public int CondicaoPreso { get; set; }
        public int Regime { get; set; }
        public string Observacoes { get; set; }

        public virtual Penitenciaria IdPenitenciariaNavigation { get; set; }
        public virtual ICollection<Matricula> Matricula { get; set; }
        public virtual ICollection<Mensagem> Mensagem { get; set; }
    }
}
