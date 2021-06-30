using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Utils;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class CursoList : ListPageBase<CursoDto>
    {
        [Inject] protected ICursoApiService CursoApiService { get; set; }

        protected override void OnInit()
        {
            State.TituloPagina = "Cursos CENED / Lista";
        }

        protected override async Task<DataTableModel<CursoDto>> Buscar(DataTableModel<CursoDto> dataTable)
        {
            State.Carregando = true;
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await CursoApiService.Filtrar(dataTable);
            State.Carregando = false;
            return dataTable;
        }
    }
}
