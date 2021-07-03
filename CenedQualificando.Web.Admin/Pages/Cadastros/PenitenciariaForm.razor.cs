using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class PenitenciariaForm : FormPageBase
    {
        private PenitenciariaDto Model { get; set; } = new PenitenciariaDto();

        protected override void OnInit()
        {
            State.TituloPagina = "Penitenciárias / Novo";
        }
    }
}