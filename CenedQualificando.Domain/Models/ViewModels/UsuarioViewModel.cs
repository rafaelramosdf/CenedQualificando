using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;
using System;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class UsuarioViewModel : ViewModel<Usuario>
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
        public AtivoEnum Ativo { get; set; }
        public string AtivoDescricao => Ativo.EnumDescription();
        public DateTime? DataExpiracaoSenha { get; set; }
        public string CpfUsuario { get; set; }

        public GrupoDePermissaoViewModel GrupoDePermissao { get; set; } = new GrupoDePermissaoViewModel();
    }
}
