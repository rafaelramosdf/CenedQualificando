using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Web.Admin.Services.ApiContracts;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class FiscalSalaList : ListPageBase<FiscalSala, FiscalSalaFilter, FiscalSalaViewModel, IFiscalSalaApiContract>
    {
        protected override void OnInit()
        {
            State.TituloPagina = "Fiscais de Sala / Lista";
        }
    }
}
