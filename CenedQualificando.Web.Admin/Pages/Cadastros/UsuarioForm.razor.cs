using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class UsuarioForm : FormPageBase
    {
        private UsuarioDto Model { get; set; } = new UsuarioDto();

        protected override void OnInit()
        {
            State.TituloPagina = "Usuários do Sistema / Novo";
        }
    }
}
