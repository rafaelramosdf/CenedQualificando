using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Utils;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class RepresentanteList : ListPageBase<RepresentanteDto>
    {
        [Inject] protected IRepresentanteApiService RepresentanteApiService { get; set; }

        protected override void OnInit()
        {
            State.TituloPagina = "Representantes / Lista";
        }

        protected override async Task<DataTableModel<RepresentanteDto>> Buscar(DataTableModel<RepresentanteDto> dataTable)
        {
            State.Carregando = true;
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await RepresentanteApiService.Filtrar(dataTable);
            State.Carregando = false;
            return dataTable;
        }
    }
}
