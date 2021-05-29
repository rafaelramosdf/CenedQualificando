using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class PenitenciariaList : ListPageBase<PenitenciariaDto>
    {
        [Inject] protected IPenitenciariaApiService PenitenciariaApiService { get; set; }

        protected override void OnInit()
        {
            State.TituloPagina = "Penitenciárias / Lista";
        }

        protected override async Task<DataTableModel<PenitenciariaDto>> Buscar(DataTableModel<PenitenciariaDto> dataTable)
        {
            State.Carregando = true;
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await PenitenciariaApiService.Filtrar(dataTable);
            State.Carregando = false;
            return dataTable;
        }
    }
}
