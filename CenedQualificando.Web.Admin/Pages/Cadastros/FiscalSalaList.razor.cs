using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class FiscalSalaList : ListPageBase<FiscalSalaDto>
    {
        [Inject] protected IFiscalSalaService FiscalSalaService { get; set; }

        protected override void OnInit()
        {
            State.TituloPagina = "Fiscais de Sala / Lista";
        }

        protected override async Task<DataTableModel<FiscalSalaDto>> Buscar(DataTableModel<FiscalSalaDto> dataTable)
        {
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await FiscalSalaService.Filtrar(dataTable);
            return dataTable;
        }
    }
}
