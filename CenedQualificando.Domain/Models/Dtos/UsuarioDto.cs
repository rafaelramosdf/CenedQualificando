using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using System;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class UsuarioDto : Dto<Usuario>
    {
        public override int Id => IdUsuario;

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int Uf { get; set; }
        public int IdGrupoDePermissao { get; set; }
        public int Ativo { get; set; }
        public DateTime? DataExpiracaoSenha { get; set; }
        public string CpfUsuario { get; set; }

        public GrupoDePermissaoDto GrupoDePermissao { get; set; }

        public override void Validate()
        {
        }
    }
}
