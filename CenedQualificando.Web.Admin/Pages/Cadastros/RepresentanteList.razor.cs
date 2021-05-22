using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class RepresentanteList : ListPageBase<RepresentanteDto>
    {
        [Inject] protected IRepresentanteService RepresentanteService { get; set; }

        protected override void OnInit()
        {
            State.TituloPagina = "Representantes / Lista";
        }

        protected override async Task<DataTableModel<RepresentanteDto>> Buscar(DataTableModel<RepresentanteDto> dataTable)
        {
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await RepresentanteService.Filtrar(dataTable);
            return dataTable;
        }
    }
}
