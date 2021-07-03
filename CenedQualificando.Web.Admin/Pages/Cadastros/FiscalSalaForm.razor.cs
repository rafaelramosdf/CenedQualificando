using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class FiscalSalaForm : FormPageBase
    {
        private FiscalSalaDto Model { get; set; } = new FiscalSalaDto();

        protected override void OnInit()
        {
            State.TituloPagina = "Fiscais de Sala / Novo";
        }
    }
}