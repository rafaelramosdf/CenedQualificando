using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Entities
{
    public partial class Penitenciaria : Entity
    {
        public Penitenciaria()
        {
            AgentePenitenciario = new HashSet<AgentePenitenciario>();
            Aluno = new HashSet<Aluno>();
            Matricula = new HashSet<Matricula>();
        }

        public override int Id => IdPenitenciaria;

        public int IdPenitenciaria { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public int Uf { get; set; }
        public string Cep { get; set; }
        public string NomeDepartamentoEnsino { get; set; }
        public string ResponsavelDepartamentoEnsino { get; set; }
        public string TituloCargoDepartamentoEnsino { get; set; }
        public string EmailContatoDepartamentoEnsino { get; set; }
        public int Ativo { get; set; }
        public bool PossuiBolsaParceria { get; set; }
        public DateTime? DataInicioBolsaParceria { get; set; }
        public int BolsasConcedidas { get; set; }

        public virtual ICollection<AgentePenitenciario> AgentePenitenciario { get; set; }
        public virtual ICollection<Aluno> Aluno { get; set; }
        public virtual ICollection<Matricula> Matricula { get; set; }
    }
}
