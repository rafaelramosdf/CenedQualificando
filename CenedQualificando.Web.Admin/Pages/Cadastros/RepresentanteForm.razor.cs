using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class RepresentanteForm : FormPageBase
    {
        private RepresentanteDto Model { get; set; } = new RepresentanteDto();

        protected override void OnInit()
        {
            State.TituloPagina = "Representantes / Novo";
        }
    }
}