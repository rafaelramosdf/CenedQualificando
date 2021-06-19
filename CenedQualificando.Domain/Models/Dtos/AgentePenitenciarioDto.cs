using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using System;

namespace CenedQualificando.Domain.Models.Dtos
{
    public class AgentePenitenciarioDto : Dto<AgentePenitenciario>
    {
        public override int Id => IdAgentePenitenciario;

        public int IdAgentePenitenciario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string CpfUsuario { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int Uf { get; set; }
        public int IdPenitenciaria { get; set; }
        public int Ativo { get; set; }
        public DateTime? DataExpiracaoSenha { get; set; }
        public int IdGrupoDePermissao { get; set; }
        public bool AgentePenitenciarioParceria { get; set; }
        public DateTime? DataInicioParceria { get; set; }

        public AgentePenitenciarioDto()
        {
        }
        public AgentePenitenciarioDto(int id,
            string nome,
            string login,
            string cpf,
            string senha,
            string telefone,
            string email,
            int uf,
            int idPenitenciaria,
            int ativo,
            int idGrupoPermissao)
        {
            Id = id;
            Nome = nome;
            Login = login;
            CpfUsuario = cpf;
            Senha = senha;
            Telefone = telefone;
            Email = email;
            Uf = uf;
            IdPenitenciaria = idPenitenciaria;
            Ativo = ativo;
            IdGrupoDePermissao = idGrupoPermissao;
        }
    }
}
