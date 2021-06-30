using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Utils;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class FiscalSalaList : ListPageBase<FiscalSalaDto>
    {
        [Inject] protected IFiscalSalaApiService FiscalSalaApiService { get; set; }

        protected override void OnInit()
        {
            State.TituloPagina = "Fiscais de Sala / Lista";
        }

        protected override async Task<DataTableModel<FiscalSalaDto>> Buscar(DataTableModel<FiscalSalaDto> dataTable)
        {
            State.Carregando = true;
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await FiscalSalaApiService.Filtrar(dataTable);
            State.Carregando = false;
            return dataTable;
        }
    }
}
