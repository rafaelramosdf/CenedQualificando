using CenedQualificando.Web.Admin.Models;
using CenedQualificando.Web.Admin.Models.Base;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class FiscalSalaList : ListPageBase<FiscalSalaModel>
    {
        [Inject] protected IFiscalSalaService FiscalSalaService { get; set; }

        protected override void OnInit()
        {
            State.TituloPagina = "Fiscais de Sala";
        }

        protected override async Task<DataTableModel<FiscalSalaModel>> Buscar(DataTableModel<FiscalSalaModel> dataTable)
        {
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await FiscalSalaService.Filtrar(dataTable);
            return dataTable;
        }
    }
}
