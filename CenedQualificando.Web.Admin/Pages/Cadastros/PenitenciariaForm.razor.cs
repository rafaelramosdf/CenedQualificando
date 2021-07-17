using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class PenitenciariaForm : FormPageBase<Penitenciaria, PenitenciariaDto, IPenitenciariaApiService>
    {
        protected override void OnInit()
        {
            State.TituloPagina = "Penitenciárias / Novo";
            BackRoute = "/cadastros/penitenciarias";
        }
    }
}